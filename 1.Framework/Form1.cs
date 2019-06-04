using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LydTOPDP.Service;
using System.Reflection;
using DevPlatform.WindowsForms.ControlLibrary;
using PickBoxTest;
using System.Collections;
using PluginLib;
using LogQuery;
using LYDTOPDP;
using System.Xml;

namespace LydTOPDP
{
    public partial class Form1 : Form
    {
        Queue ShareDateQueue = new Queue();
        BaseForm currentPluginForm = null;
        NavBtnItem currentBtn = null;

        public Form1()
        {
            InitializeComponent();
        }

        #region 回调事件
        //插件通过事件回调此方法，输出信息到文本控件
        private void WriteMessage(string message)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            richTextBox1.Text += message;
            this.richTextBox1.Select(this.richTextBox1.TextLength, 0);
            this.richTextBox1.ScrollToCaret();
        }

        //插件通过事件回调此方法，输出信息到文本控件
        private void ClearMessage()
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            richTextBox1.Text = "";
        }

        //插件通过事件毁掉方法，将数据写入内存
        private void PushData(object data)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            ShareDateQueue.Enqueue(data);
        }

        private Queue PopupData()
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            return ShareDateQueue;
        }

        private void SetPrograss(String type, String message, int? percent)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            if (percent != null && percent >= 0 && percent <= 100)
            {
                progressBarInfo.Value = (int)percent;
            }
            if (!string.IsNullOrEmpty(type))
            {
                toolStripStatusLabel2.Text = type;
            }
            if (!string.IsNullOrEmpty(message))
            {
                toolStripStatusLabel1.Text = message;
            }
            //Form.CheckForIllegalCrossThreadCalls = true;
        }

        private void SetProgressMaxValue(int value)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            progressBarInfo.Maximum = value;
        }

        private void ResetProgressMaxValue()
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            progressBarInfo.Maximum = 100;
        }

        //写系统日志
        private void LogOperatorInfo(string strCaoZuoLeiXing, string strZhiLingNeiRong, bool ifSuccess)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            AccessClass ac = new AccessClass();//定义Access数据库操作类对象
            ac.AddCaoZuoList(strCaoZuoLeiXing, strZhiLingNeiRong, ifSuccess);
        }

        private void LogSystemInfo(string strCaoZuoLeingXing, string strZhiLingNeiRong, string strErrorContent)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            AccessClass ac = new AccessClass();//定义Access数据库操作类对象
            ac.AddErrotList(strCaoZuoLeingXing, strZhiLingNeiRong, strErrorContent);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void navigationPan2_Load(object sender, EventArgs e)
        {

        }

        void InitForm()
        {
            //if (checkBox1.Checked)
            //{
            //    splitContainer1.Panel2.Show();
            //}
            //else
            //{
            //    splitContainer1.Panel2.Hide();
            //}

            #region 初始化左侧导航菜单
            MenuService leftMenuService = new MenuService();
            IList<string[]> leftMenus = leftMenuService.GetNavLeftMenuItem();
            navLeftMenu1.Items = leftMenus;
            #endregion
            #region 插件操作
            //linkLabel1_LinkClicked(null, null);
            #endregion


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        void CreateBtnImage(PictureBox pic, String caption)
        {
            Graphics g = Graphics.FromImage(pic.Image);//得到按钮背景图片

            Font font = new Font("宋体", 14, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.FromArgb(244, 155, 155));

            float posX = pic.Image.Size.Width / 2 - g.MeasureString(caption, font).Width / 2;
            float posY = pic.Image.Size.Height - g.MeasureString(caption, font).Height - 13;
            g.DrawString(caption, font, brush, posX, posY);
            pic.Size = pic.Image.Size;
            pic.Visible = true;
        }

        private void navLeftMenu1_NavButtonItemClick(object sender, EventArgs e)
        {
            #region 判断当前是否存在打开的插件
            if (currentPluginForm != null)
            {
                if (currentPluginForm.CloseForm() == DialogResult.Cancel)
                {
                    return;
                }
                currentPluginForm = null;
            }
            #endregion
            flowLayoutPanel1.Controls.Clear();
            panel4.Controls.Clear();
            SetPrograss("就绪", " ", 0);

            FlowLayoutPanel flp = new FlowLayoutPanel();
            panel4.Controls.Add(flp);
            flp.Dock = DockStyle.Fill;
            flp.Visible = true;

            label1.Text = (sender as Button).Text;
            label1.Tag = (sender as Button).Tag;

            #region 查找插件
            PluginService pgService = new PluginService();
            IList<PluginModel> items = pgService.GetPluginItems(int.Parse(label1.Tag.ToString()));


            string sortXml = AppDomain.CurrentDomain.BaseDirectory + @"/ConfigData/pluginSort.xml";
            XmlDocument xmlDocSort = new XmlDocument();
            xmlDocSort.Load(sortXml);
            XmlNodeList funItemList = xmlDocSort.SelectNodes("sort/fun_" + int.Parse(label1.Tag.ToString()) + "/item");

            foreach (XmlNode el in funItemList)
            {
                //foreach (PluginPro item in items)
                //{
                //if (item.Items == null) continue;
                foreach (PluginModel pm in items)
                {
                    if (el.Attributes["guid"].Value == pm.GUID)
                    {
                        NavBtnItem btnItem = new NavBtnItem();
                        btnItem.Text = pm.Text;
                        btnItem.SelectedChanged += new NavBtnItem.SelectedHandler(btnItem_SelectedChanged);
                        btnItem.Tag = pm;
                        btnItem.Tag1 = pm.LibPath;
                        btnItem.Tag2 = pm.GUID;
                        flowLayoutPanel1.Controls.Add(btnItem);

                        PictureBox pic = new PictureBox();
                        pic.Tag = btnItem;
                        pic.Cursor = Cursors.Arrow;
                        pic.Click += delegate(object sender1, EventArgs e1)
                        {
                            NavBtnItem btnItem1 = (NavBtnItem)(sender1 as PictureBox).Tag;
                            btnItem_SelectedChanged(btnItem1, e1);
                        };
                        pic.MouseMove += delegate(object sender1, MouseEventArgs e1)
                        {
                            pic.Image = global::LYDTOPDP.Properties.Resources.btn11;
                            CreateBtnImage(pic, btnItem.Text);
                        };
                        pic.MouseLeave += delegate(object sender1, EventArgs e1)
                        {
                            pic.Image = global::LYDTOPDP.Properties.Resources.btn;
                            CreateBtnImage(pic, btnItem.Text);
                        };
                        pic.Image = global::LYDTOPDP.Properties.Resources.btn;
                        flp.Controls.Add(pic);
                        CreateBtnImage(pic, btnItem.Text);
                    }
                }
                //}
            }



            #endregion
        }

        protected void btnItem_SelectedChanged(object sender, EventArgs e)
        {
            #region 判断当前是否存在打开的插件
            if (currentBtn != null && currentBtn.Equals(sender))
            {
                return;
            }
            else
            {

            }

            if (currentPluginForm != null)
            {
                if (currentPluginForm.CloseForm() == DialogResult.Cancel)
                {
                    (sender as NavBtnItem).Selected = false;
                    return;
                }
            }
            #endregion
            currentBtn = sender as NavBtnItem;
            SetPrograss("就绪", " ", 0);
            foreach (NavBtnItem item in flowLayoutPanel1.Controls)
            {
                item.Selected = false;
            }
            (sender as NavBtnItem).Selected = true;
            PluginModel pp = (sender as NavBtnItem).Tag as PluginModel;
            Assembly ass = Assembly.LoadFrom(pp.LibPath);

            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(pp.LibPath);

            string pluginClassName = ass.GetName().Name + "." + (sender as NavBtnItem).Tag2;
            string guid = (sender as NavBtnItem).Tag2.ToString();
            //foreach (PluginModel pm in pp.Items)
            //{
            //    if (guid == pm.GUID)
            //    {
            //        pluginClassName = pm.Namesapce + "." + pm.Name;
            //        break;
            //    }
            //}

            Type tp = ass.GetType(pluginClassName);

            if (tp == null)
            {
                MessageBox.Show("插件加载失败:" + pluginClassName);
                return;
            }
            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(pp.LibPath);
            Form pluginClass = Activator.CreateInstance(tp) as Form;
            if (pluginClass is PluginLib.BaseForm)
            {
                currentPluginForm = pluginClass as PluginLib.BaseForm;
            }
            else
            {
                currentPluginForm = null;
            }
            pluginClass.TopLevel = false;
            pluginClass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            pluginClass.Dock = DockStyle.Top;
            pluginClass.FormBorderStyle = FormBorderStyle.None;
            panel4.Controls.Clear();
            panel4.Controls.Add(pluginClass);
            pluginClass.Visible = true;

            //pluginClassName = pp.Namespace + ".Plugin";
            tp = ass.GetType(pluginClassName);
            tp = tp.BaseType;

            #region 为plugin.cs文件中的消息处理事件添加委托方法
            EventInfo eiMessage = tp.GetEvent("message");
            eiMessage.RemoveEventHandler(this, Delegate.CreateDelegate(eiMessage.EventHandlerType, this, "WriteMessage"));
            eiMessage.AddEventHandler(this, Delegate.CreateDelegate(eiMessage.EventHandlerType, this, "WriteMessage"));

            EventInfo eiClear = tp.GetEvent("clear");
            eiClear.RemoveEventHandler(this, Delegate.CreateDelegate(eiClear.EventHandlerType, this, "ClearMessage"));
            eiClear.AddEventHandler(this, Delegate.CreateDelegate(eiClear.EventHandlerType, this, "ClearMessage"));

            EventInfo eiPushData = tp.GetEvent("pushData");
            eiPushData.RemoveEventHandler(this, Delegate.CreateDelegate(eiPushData.EventHandlerType, this, "PushData"));
            eiPushData.AddEventHandler(this, Delegate.CreateDelegate(eiPushData.EventHandlerType, this, "PushData"));

            EventInfo eiPopupData = tp.GetEvent("popupData");
            eiPopupData.RemoveEventHandler(this, Delegate.CreateDelegate(eiPopupData.EventHandlerType, this, "PopupData"));
            eiPopupData.AddEventHandler(this, Delegate.CreateDelegate(eiPopupData.EventHandlerType, this, "PopupData"));

            EventInfo eiPrograss = tp.GetEvent("PrograssInfo");
            eiPrograss.RemoveEventHandler(this, Delegate.CreateDelegate(eiPrograss.EventHandlerType, this, "SetPrograss"));
            eiPrograss.AddEventHandler(this, Delegate.CreateDelegate(eiPrograss.EventHandlerType, this, "SetPrograss"));

            EventInfo eiPrograssMaxValue = tp.GetEvent("ProgressMaxValue");
            eiPrograssMaxValue.RemoveEventHandler(this, Delegate.CreateDelegate(eiPrograssMaxValue.EventHandlerType, this, "SetProgressMaxValue"));
            eiPrograssMaxValue.AddEventHandler(this, Delegate.CreateDelegate(eiPrograssMaxValue.EventHandlerType, this, "SetProgressMaxValue"));

            EventInfo resetProgressMaxValue = tp.GetEvent("resetProgressMaxValue");
            resetProgressMaxValue.RemoveEventHandler(this, Delegate.CreateDelegate(resetProgressMaxValue.EventHandlerType, this, "ResetProgressMaxValue"));
            resetProgressMaxValue.AddEventHandler(this, Delegate.CreateDelegate(resetProgressMaxValue.EventHandlerType, this, "ResetProgressMaxValue"));

            EventInfo eiLogOpt = tp.GetEvent("LogOperatorInfo");
            eiLogOpt.RemoveEventHandler(this, Delegate.CreateDelegate(eiLogOpt.EventHandlerType, this, "LogOperatorInfo"));
            eiLogOpt.AddEventHandler(this, Delegate.CreateDelegate(eiLogOpt.EventHandlerType, this, "LogOperatorInfo"));

            EventInfo eiLogSystem = tp.GetEvent("LogSystemInfo");
            eiLogSystem.RemoveEventHandler(this, Delegate.CreateDelegate(eiLogSystem.EventHandlerType, this, "LogSystemInfo"));
            eiLogSystem.AddEventHandler(this, Delegate.CreateDelegate(eiLogSystem.EventHandlerType, this, "LogSystemInfo"));
            #endregion

            #region 传递通讯方式信息
            CommunicationData data = ConfigDataService.GetCommunicationData();

            Object pgClass = Activator.CreateInstance(tp);

            MethodInfo methodInfo = tp.GetMethod("SetSerialPort");
            methodInfo.Invoke(pgClass, new object[] { data.Serialport, data.Baudrate });

            methodInfo = tp.GetMethod("SetNetwork");
            methodInfo.Invoke(pgClass, new object[] { data.IP, data.Localport, data.Remoteport });

            #endregion
        }

        protected void bigItem_Selected(object sender, EventArgs e)
        {
            string frmName = (sender as NavigationItemBig).Tag.ToString();
            Type type = Type.GetType(frmName);
            Form frm = type.Assembly.CreateInstance(frmName) as Form;

            frm.TopLevel = false;
            frm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            //frm.Left = 0;
            //frm.Top = 0;
            //frm.Width = panel4.Width;
            //frm.Height = panel4.Height;
            frm.Dock = DockStyle.None;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel4.Controls.Clear();
            panel4.Controls.Add(frm);
            frm.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            label1.Text = "系统设置";
            NavBtnItem btnItem = new NavBtnItem();
            btnItem.Text = "通讯设置";
            btnItem.SelectedChanged += new NavBtnItem.SelectedHandler(btnItemSysteConfig_SelectedChanged);
            btnItem.Tag = "LydTOPDP.FrmSysSetting";
            flowLayoutPanel1.Controls.Add(btnItem);

            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.Padding = new Padding(10, 5, 5, 5);
            flowPanel.AutoScroll = true;
            flowPanel.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(flowPanel);
        }

        protected void btnItemSysteConfig_SelectedChanged(object sender, EventArgs e)
        {
            foreach (NavBtnItem item in flowLayoutPanel1.Controls)
            {
                item.Selected = false;
            }
            FrmSysSetting sysFrm = new FrmSysSetting();

            sysFrm.TopLevel = false;
            //sysFrm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            sysFrm.Dock = DockStyle.None;
            sysFrm.FormBorderStyle = FormBorderStyle.None;
            panel4.Controls.Clear();
            panel4.Controls.Add(sysFrm);
            sysFrm.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //{
            //    richTextBox1.Visible = true;
            //    panel4.Dock = DockStyle.Fill;
            //}
            //else
            //{
            //    richTextBox1.Visible = false;
            //    panel4.Dock = DockStyle.None;
            //}
        }

        private void navLeftMenu1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PInfo.ds = PInfo.Data_Source.TVPlayer;
            QueryForm qf = new QueryForm();
            qf.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PluginManagerForm().Show();
        }
    }
}
