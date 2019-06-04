using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PluginLib
{
    /// <summary>
    /// 早期插件需几成此窗体
    /// </summary>
    [Obsolete("已过时，建议使用BaseFormV2")]
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 插件关闭时被调用，插件可决定是否被关闭，插件需实现此方法
        /// </summary>
        /// <returns>DialogResult.OK允许关闭，DialogResult.Cancel取消关闭</returns>
        public virtual DialogResult CloseForm()
        {
            return DialogResult.OK;
        }

        /// <summary>
        /// 箱体类型改变时被调用，插件需实现此方法
        /// </summary>
        public virtual void PanelTypeChanged()
        {

        }

        /// <summary>
        /// 通讯方式改变时被调用，插件需实现此方法
        /// </summary>
        public virtual void CommunicationTypeChanged()
        {

        }

        /// <summary>
        /// 箱体地址变化时被调用，插件需实现此方法
        /// </summary>
        /// <param name="unit_x"></param>
        /// <param name="unit_y"></param>
        public virtual void UnitAddrChanged(int unit_x, int unit_y)
        {

        }

        /// <summary>
        /// 组地址变化时被调用，插件需实现此方法
        /// </summary>
        /// <param name="unit_x"></param>
        /// <param name="unit_y"></param>
        public virtual void GroupAddrChanged(int unit_x, int unit_y)
        {

        }
        /// <summary>
        /// 命令发送等待时间发生变化时被调用，插件需实现此方法
        /// </summary>
        /// <param name="sendTime"></param>
        /// <param name="reciTime"></param>
        public virtual void WaitTimeChanged(int sendTime, int reciTime)
        {
        }

        /// <summary>
        /// TV PLAYER类型发生变化时被调用，插件需实现此方法
        /// </summary>
        /// <param name="playerType">player类型</param>
        /// <param name="outputType">输出口类别</param>
        public virtual void TVPlayerChanged(PlayerType playerType, OutputType outputType)
        {
        }

        /// <summary>
        /// TV PLAYER类型发生变化时被调用，插件需实现此方法
        /// </summary>
        [Obsolete("建议使用TVPlayerChanged(PlayerType playerType,OutputType outputType)方法")]
        public virtual void TVPlayerChanged()
        {
        }

        /// <summary>
        /// 是否显示发送、接收数据包发生变化时调用，插件需实现此方法，以便可以通过框架开启或者关闭数据包监视功能
        /// </summary>
        /// <param name="isShowDataPackage">true:显示数据包,false：不显示数据包</param>
        public virtual void ShowDataPackageChanged(bool isShowDataPackage)
        {

        }

        /// <summary>
        /// 输出口发生变化时被调用，插件需实现此方法
        /// </summary>
        public virtual void OutPutChanged()
        {
        }

        /// <summary>
        /// 此方法不在使用
        /// </summary>
        /// <param name="color"></param>
        public virtual void SetBackColor(Color color)
        {
            this.BackColor = color;
        }

        /// <summary>
        /// 插件重新激活时被调用，
        /// </summary>
        public virtual void ReActived()
        { 
        }

        /// <summary>
        /// 是否正在执行命令
        /// </summary>
        private bool isCurrExec = false;
        /// <summary>
        /// 当前页面是否有程序正在执行
        /// </summary>
        public bool IsCurrExec
        {
            get { return isCurrExec; }
            set { isCurrExec = value; }
        }
        private string currName = "";
        /// <summary>
        /// 正在执行程序的名称
        /// </summary>
        public string CurrName
        {
            get { return currName; }
            set { currName = value; }
        }

    }
}
