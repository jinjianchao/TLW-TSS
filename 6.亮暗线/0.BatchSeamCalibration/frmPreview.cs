using LanguageLib;
using PluginLib;
using SFTHelper.Structs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TLWCommunication;

namespace BatchSeamCalibration
{
    public partial class frmPreview : Form
    {
        public class EventArgEx : EventArgs
        {
            public SelectedBorder SelectedBorder { get; set; }
        }

        public TLWCommand _baseCommunication;//通讯操作类
        public string IP = "";

        public event EventHandler<EventArgEx> SelectedBorderChanged;

        private readonly String lang = MultiLanguage.ReadDefaultLanguage(); //读取语言包信息
        private string _workPath = "";
        StructSeamItem[,] _seamData;
        int[,] _seamDataTopSelectedFlag;
        int[,] _seamDataRightSelectedFlag;
        int[,] _seamDataBottomSelectedFlag;
        int[,] _seamDataLeftSelectedFlag;
        Bitmap _bmpBuffer = null;
        bool _mouseIsDown = false;
        UnitTypeV2 _cabinetType;
        Rectangle _mouseRect = Rectangle.Empty;
        bool _ctrKey = false;//Control键
        bool _shiftKey = false;//Shift

        Point _currentFormLocation = new Point(); //当前窗体位置
        Point _currentMouseOffset = new Point(); //当前鼠标的按下位置

        public UserIPCommand SelectedIPCommand { get; set; }

        public StructSeamItem[,] SeamData
        {
            get { return _seamData; }
            set { _seamData = value; }
        }

        public InterfaceData InterfaceData { get; set; }

        public bool Lock { get; set; }

        public UnitTypeV2 CabinetType
        {
            get { return _cabinetType; }
            set { _cabinetType = value; Init(); }
        }

        /// <summary>
        /// 调整幅度
        /// </summary>
        public int adjustRange { get; set; }

        //public SelectedBorder GetSelectedBorder()
        //{
        //    SelectedBorder selected = new SelectedBorder();
        //    selected.Left = _seamDataLeftSelectedFlag;
        //    selected.Top = _seamDataTopSelectedFlag;
        //    selected.Right = _seamDataRightSelectedFlag;
        //    selected.Bottom = _seamDataBottomSelectedFlag;
        //    return selected;
        //}

        public SelectedBorder SelectedBorder
        {
            get
            {
                SelectedBorder selected = new SelectedBorder();
                selected.Left = _seamDataLeftSelectedFlag;
                selected.Top = _seamDataTopSelectedFlag;
                selected.Right = _seamDataRightSelectedFlag;
                selected.Bottom = _seamDataBottomSelectedFlag;
                return selected;
            }
            set
            {
                _seamDataLeftSelectedFlag = value.Left;
                _seamDataTopSelectedFlag = value.Top;
                _seamDataRightSelectedFlag = value.Right;
                _seamDataBottomSelectedFlag = value.Bottom;
            }
        }

        public void ClearBG()
        {
            Graphics frmG = this.CreateGraphics();
            frmG.Clear(Color.FromArgb(InterfaceData.Background, InterfaceData.Background, InterfaceData.Background));
            frmG.Dispose();
            frmG = null;
            GC.Collect();
        }

        public void Draw()
        {
            CreateBMPBuffer();
            if (_seamData != null)
            {
                //CreateRectangles();
                if (InterfaceData.ShowBorder) DrawRectangleBorder();
                if (InterfaceData.ShowPercentValue) DrawPercentValue();
                if (!InterfaceData.ShowBorder) DrawPreviewLine();
                DrawSelectedBorder();
            }
            DrawFormPoint();
            Graphics g = this.CreateGraphics();
            g.DrawImage(_bmpBuffer, 0, 0);
            g.Dispose();
            g = null;
            GC.Collect();
        }

        private void ResizeToRectangle1(Point p)
        {
            DrawRectangle1();
            _mouseRect.Width = p.X - _mouseRect.Left;
            _mouseRect.Height = p.Y - _mouseRect.Top;
            DrawRectangle1();
        }

        private void DrawRectangle1()
        {
            Console.WriteLine(_mouseRect.ToString());
            Rectangle rect = this.RectangleToScreen(_mouseRect);
            ControlPaint.DrawReversibleFrame(rect, Color.White, FrameStyle.Dashed);
        }

        private void DrawStart1(Point StartPoint)
        {
            this.Capture = true;
            Cursor.Clip = this.RectangleToScreen(new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
            _mouseRect = new Rectangle(StartPoint.X, StartPoint.Y, 0, 0);
        }

        public void Init()
        {
            UnitTypeV2 uType = CabinetType;
            _seamDataTopSelectedFlag = new int[uType.ModuleHeight, uType.ModuleWidth];
            _seamDataRightSelectedFlag = new int[uType.ModuleHeight, uType.ModuleWidth];
            _seamDataBottomSelectedFlag = new int[uType.ModuleHeight, uType.ModuleWidth];
            _seamDataLeftSelectedFlag = new int[uType.ModuleHeight, uType.ModuleWidth];
        }

        void CreateBMPBuffer()
        {
            UnitTypeV2 utype = CabinetType;
            _bmpBuffer = new Bitmap(utype.GetSize().Width, utype.GetSize().Height);
            Graphics g = Graphics.FromImage(_bmpBuffer);
            g.Clear(Color.FromArgb(InterfaceData.Background, InterfaceData.Background, InterfaceData.Background));
            g.Dispose();
            g = null;
            GC.Collect();
        }

        void DrawRectangleBorder()
        {
            Graphics g = Graphics.FromImage(_bmpBuffer);
            Pen redPen = new Pen(Color.Red);
            for (int i = 0; i < _seamData.GetLength(0); i++)
            {
                for (int j = 0; j < _seamData.GetLength(1); j++)
                {
                    g.DrawRectangle(redPen, _seamData[i, j].RectangleAll);
                }
            }
            g.Dispose();
            g = null;
            GC.Collect();
        }

        void DrawPercentValue()
        {
            Graphics g = Graphics.FromImage(_bmpBuffer);
            Brush brush = Brushes.Blue;
            Font font = new Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < _seamData.GetLength(0); i++)
            {
                for (int j = 0; j < _seamData.GetLength(1); j++)
                {
                    //上
                    float percent = _seamData[i, j].Top;
                    Rectangle rect = _seamData[i, j].RectangleTop;
                    g.DrawString(percent.ToString("F0"), font, brush, rect, format);

                    //下
                    percent = _seamData[i, j].Bottom;
                    rect = _seamData[i, j].RectangleBottom;
                    g.DrawString(percent.ToString("F0"), font, brush, rect, format);

                    //右
                    percent = _seamData[i, j].Right;
                    rect = _seamData[i, j].RectangleRight;
                    g.DrawString(percent.ToString("F0"), font, brush, rect, format);

                    //左
                    percent = _seamData[i, j].Left;
                    rect = _seamData[i, j].RectangleLeft;
                    g.DrawString(percent.ToString("F0"), font, brush, rect, format);
                }
            }
            g.Dispose();
            g = null;
            GC.Collect();
        }

        void DrawFormPoint()
        {
            Graphics g = Graphics.FromImage(_bmpBuffer);
            Brush brush = Brushes.Red;
            Font font = new Font("宋体", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;

            Rectangle rect = new Rectangle(2, 2, 70, 20);
            string pos = string.Format("({0},{1})", this.Left, this.Top);
            g.DrawString(pos, font, brush, rect, format);

            g.Dispose();
            g = null;
            GC.Collect();
        }

        void DrawPreviewLine()
        {
            Graphics g = Graphics.FromImage(_bmpBuffer);
            Color backgroundColor = Color.FromArgb(InterfaceData.Background, InterfaceData.Background, InterfaceData.Background);
            for (int i = 0; i < _seamData.GetLength(0); i++)
            {
                for (int j = 0; j < _seamData.GetLength(1); j++)
                {
                    float percent = _seamData[i, j].Left;
                    //if (percent != 100)

                    int r = (int)(backgroundColor.R * _seamData[i, j].Left / adjustRange);
                    int gC = (int)(backgroundColor.B * _seamData[i, j].Left / adjustRange);
                    int b = (int)(backgroundColor.G * _seamData[i, j].Left / adjustRange);
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (gC > 255) gC = 255;
                    if (gC < 0) gC = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    Color color = Color.FromArgb(r, gC, b);
                    Pen p = new Pen(color);
                    g.DrawLines(p, _seamData[i, j].PreviewLineLeft.ToArray());

                    r = (int)(backgroundColor.R * _seamData[i, j].Top / adjustRange);
                    gC = (int)(backgroundColor.B * _seamData[i, j].Top / adjustRange);
                    b = (int)(backgroundColor.G * _seamData[i, j].Top / adjustRange);
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (gC > 255) gC = 255;
                    if (gC < 0) gC = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    color = Color.FromArgb(r, gC, b);
                    p = new Pen(color);
                    g.DrawLines(p, _seamData[i, j].PreviewLineTop.ToArray());

                    r = (int)(backgroundColor.R * _seamData[i, j].Right / adjustRange);
                    gC = (int)(backgroundColor.B * _seamData[i, j].Right / adjustRange);
                    b = (int)(backgroundColor.G * _seamData[i, j].Right / adjustRange);
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (gC > 255) gC = 255;
                    if (gC < 0) gC = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    color = Color.FromArgb(r, gC, b);
                    p = new Pen(color);
                    g.DrawLines(p, _seamData[i, j].PreviewLineRight.ToArray());

                    r = (int)(backgroundColor.R * _seamData[i, j].Bottom / adjustRange);
                    gC = (int)(backgroundColor.B * _seamData[i, j].Bottom / adjustRange);
                    b = (int)(backgroundColor.G * _seamData[i, j].Bottom / adjustRange);
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (gC > 255) gC = 255;
                    if (gC < 0) gC = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    color = Color.FromArgb(r, gC, b);
                    p = new Pen(color);
                    g.DrawLines(p, _seamData[i, j].PreviewLineBottom.ToArray());
                }
            }
            g.Dispose();
            g = null;
            GC.Collect();
        }

        void ChangePercent(int dir)
        {
            if (dir == 0)
            {
                //上
                for (int i = 0; i < _seamData.GetLength(0); i++)
                {
                    for (int j = 0; j < _seamData.GetLength(1); j++)
                    {

                        if (_seamDataTopSelectedFlag[i, j] == 1)
                        {
                            _seamData[i, j].Top += 1f;
                        }
                        if (_seamDataLeftSelectedFlag[i, j] == 1)
                        {
                            _seamData[i, j].Left += 1f;
                        }
                        if (_seamDataBottomSelectedFlag[i, j] == 1)
                        {
                            _seamData[i, j].Bottom += 1f;
                        }
                        if (_seamDataRightSelectedFlag[i, j] == 1)
                        {
                            _seamData[i, j].Right += 1f;
                        }
                    }
                }
            }
            else if (dir == 1)
            {
                //下
                //int[,] _seamDataTopSelectedFlag;
                //int[,] _seamDataRightSelectedFlag;
                //int[,] _seamDataBottomSelectedFlag;
                //int[,] _seamDataleftSelectedFlag;

                for (int i = 0; i < _seamData.GetLength(0); i++)
                {
                    for (int j = 0; j < _seamData.GetLength(1); j++)
                    {
                        if (_seamDataTopSelectedFlag[i, j] == 1)
                        {
                            _seamData[i, j].Top -= 1f;
                        }
                        if (_seamDataLeftSelectedFlag[i, j] == 1)
                        {
                            _seamData[i, j].Left -= 1f;
                        }
                        if (_seamDataBottomSelectedFlag[i, j] == 1)
                        {
                            _seamData[i, j].Bottom -= 1f;
                        }
                        if (_seamDataRightSelectedFlag[i, j] == 1)
                        {
                            _seamData[i, j].Right -= 1f;
                        }
                    }
                }
            }
            Draw();
        }

        void SetSelectedBorder()
        {
            Rectangle frameRect = _mouseRect;
            if (frameRect.Width < 0)
            {
                frameRect.X = frameRect.X + frameRect.Width;
                frameRect.Width = Math.Abs(frameRect.Width);
            }
            if (_mouseRect.Height < 0)
            {
                frameRect.Y = frameRect.Y + frameRect.Height;
                frameRect.Height = Math.Abs(frameRect.Height);
            }
            Graphics g = Graphics.FromImage(_bmpBuffer);
            for (int i = 0; i < _seamData.GetLength(0); i++)
            {
                for (int j = 0; j < _seamData.GetLength(1); j++)
                {
                    StructSeamItem item = _seamData[i, j];
                    if (frameRect.IntersectsWith(item.RectangleLeft))
                    {
                        _seamDataLeftSelectedFlag[i, j] = 1;
                    }
                    else
                    {
                        if (!_ctrKey) _seamDataLeftSelectedFlag[i, j] = 0;
                    }
                    if (frameRect.IntersectsWith(item.RectangleTop))
                    {
                        _seamDataTopSelectedFlag[i, j] = 1;
                    }
                    else
                    {
                        if (!_ctrKey) _seamDataTopSelectedFlag[i, j] = 0;
                    }
                    if (frameRect.IntersectsWith(item.RectangleRight))
                    {
                        _seamDataRightSelectedFlag[i, j] = 1;
                    }
                    else
                    {
                        if (!_ctrKey) _seamDataRightSelectedFlag[i, j] = 0;
                    }
                    if (frameRect.IntersectsWith(item.RectangleBottom))
                    {
                        _seamDataBottomSelectedFlag[i, j] = 1;
                    }
                    else
                    {
                        if (!_ctrKey) _seamDataBottomSelectedFlag[i, j] = 0;
                    }
                }
            }
            g.Dispose();
            g = null;
            GC.Collect();
        }

        void DrawSelectedBorder()
        {
            Graphics g = Graphics.FromImage(_bmpBuffer);
            Pen pen = new Pen(Color.Blue);
            for (int i = 0; i < _seamData.GetLength(0); i++)
            {
                for (int j = 0; j < _seamData.GetLength(1); j++)
                {
                    StructSeamItem item = _seamData[i, j];
                    if (_seamDataLeftSelectedFlag[i, j] == 1)
                    {
                        g.DrawLines(pen, item.AreaLineLeft.ToArray());
                    }
                    if (_seamDataTopSelectedFlag[i, j] == 1)
                    {
                        g.DrawLines(pen, item.AreaLineTop.ToArray());
                    }
                    if (_seamDataRightSelectedFlag[i, j] == 1)
                    {
                        g.DrawLines(pen, item.AreaLineRight.ToArray());
                    }
                    if (_seamDataBottomSelectedFlag[i, j] == 1)
                    {
                        g.DrawLines(pen, item.AreaLineBottom.ToArray());
                    }
                }
            }
            g.Dispose();
            g = null;
            GC.Collect();
        }

        public frmPreview(string path)
        {
            InitializeComponent();
            _workPath = path;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MultiLanguage.GetNames(this, lang, _workPath + @"\Language");
            //Init();
            //InitialData();

            ctxShowBorder.Text = MultiLanguage.GetNames(this.Name, "showborder");
            ctxShowValue.Text = MultiLanguage.GetNames(this.Name, "showpercent");
            ctxClose.Text = MultiLanguage.GetNames(this.Name, "close");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.ShiftKey)
            {
            }
            if (keyData == Keys.ControlKey)
            {
            }

            if (keyData == Keys.Up)
            {
                ChangePercent(0);
            }
            if (keyData == Keys.Down)
            {
                ChangePercent(1);
            }

            if (!Lock)
            {
                if (keyData == Keys.A)
                {
                    this.Left -= 1;
                }
                else if (keyData == Keys.S)
                {
                    this.Top += 1;
                }
                else if (keyData == Keys.D)
                {
                    this.Left += 1;
                }
                else if (keyData == Keys.W)
                {
                    this.Top -= 1;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                return;
            }
            _mouseIsDown = true;

            if (_shiftKey && !Lock)
            {
                _currentFormLocation = this.Location;
                _currentMouseOffset = Control.MousePosition;
            }
            else
            {
                if (!_ctrKey)
                    Init();
                Draw();
                DrawStart1(e.Location);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_shiftKey && !Lock)
            {
                int rangeX = 0, rangeY = 0; //计算当前鼠标光标的位移，让窗体进行相同大小的位移
                if (_mouseIsDown)
                {
                    Point pt = Control.MousePosition;
                    rangeX = _currentMouseOffset.X - pt.X;
                    rangeY = _currentMouseOffset.Y - pt.Y;
                    this.Location = new Point(_currentFormLocation.X - rangeX, _currentFormLocation.Y - rangeY);
                }
            }
            else
            {
                if (_mouseIsDown)
                {
                    ResizeToRectangle1(e.Location);
                    if (_seamData != null)
                    {
                        SetSelectedBorder();
                        if (SelectedBorderChanged != null)
                        {
                            SelectedBorderChanged(this, new EventArgEx() { SelectedBorder = this.SelectedBorder });
                        }
                    }
                    Draw();
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                return;
            }
            this.Capture = false;
            Cursor.Clip = Rectangle.Empty;
            _mouseIsDown = false;

            DrawRectangle1();
            _mouseRect = Rectangle.Empty;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _ctrKey = true;
            }
            else if (e.KeyCode == Keys.ShiftKey) //判断Alt键if (e.KeyCode == Keys.Alt)
            {
                _shiftKey = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _ctrKey = false;
            }
            else if (e.KeyCode == Keys.ShiftKey) //判断Alt键if (e.KeyCode == Keys.Alt)
            {
                _shiftKey = false;
            }
        }

        private void frmPreview_Move(object sender, EventArgs e)
        {
            //if (InterfaceData != null)
            //{
            //    InterfaceData.ViewFormPosition = new Point(this.Left, this.Top);
            //}
            if (SelectedIPCommand != null)
            {
                SelectedIPCommand.Tag4 = this.Location;
            }
        }

        private void frmPreview_Deactivate(object sender, EventArgs e)
        {
            Draw();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void ctxShowBorder_Click(object sender, EventArgs e)
        {
            ctxShowBorder.Checked = !ctxShowBorder.Checked;
            InterfaceData.ShowBorder = ctxShowBorder.Checked;
        }

        private void ctxShowValue_Click(object sender, EventArgs e)
        {
            ctxShowValue.Checked = !ctxShowValue.Checked;
            InterfaceData.ShowPercentValue = ctxShowValue.Checked;
        }

        private void ctxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        ushort GetMBAddr(int x, int y)
        {
            ushort cardAddr = (ushort)(x << 8 | y);
            if (x >= 241 || x >= 241)
            {
                //主板地址
                cardAddr = (ushort)(x << 8 | y);
            }
            else
            {
                int tmpY = y;
                int tmpX = x;
                if (this.CabinetType.Serial == "TSS")
                {
                    if (y % CabinetType.ConnectModuleCount == 0)
                    {
                        tmpY = y / CabinetType.ConnectModuleCount;
                    }
                    else
                    {
                        tmpY = y / CabinetType.ConnectModuleCount + 1;
                    }
                }
                else if (this.CabinetType.Serial == "TLW")
                {
                    if (x % CabinetType.ConnectModuleCount == 0)
                    {
                        tmpX = x / CabinetType.ConnectModuleCount;
                    }
                    else
                    {
                        tmpX = x / CabinetType.ConnectModuleCount + 1;
                    }
                }
                cardAddr = (ushort)(tmpX << 8 | tmpY);
            }
            return cardAddr;
        }

        private void ctxInit_Click(object sender, EventArgs e)
        {
            int mX = MousePosition.X - this.Left;
            int mY = MousePosition.Y - this.Top;
            int x, y;
            x = y = 0;
            for (int i = 0; i < this._cabinetType.ModuleHeight; i++)
            {
                bool isFind = false;
                for (int j = 0; j < _cabinetType.ModuleWidth; j++)
                {
                    Rectangle rect = new Rectangle(j * _cabinetType.ModulePixelWidth, i * _cabinetType.ModulePixelHeight, _cabinetType.ModulePixelWidth, _cabinetType.ModulePixelHeight);
                    if (rect.IntersectsWith(new Rectangle(mX, mY, 1, 1)))
                    {
                        x = j;
                        y = i;
                        isFind = true;
                        break;
                    }
                }
                if (isFind) break;
            }

            int addrX = _cabinetType.ModuleWidth - x;
            int addrY = _cabinetType.ModuleHeight - y;
            //MessageBox.Show(addrX + "_" + addrY);
            int dev = _baseCommunication.OpenUDP(IP);
            if (dev != 0)
            {
                _baseCommunication.tlw_ConnectCardLoadParam(dev, GetMBAddr(addrX, addrY), 0, 1);
                if (y % 2 == 0)
                {
                    SeamData[y, x].Left = SeamData[y, x].Top = SeamData[y, x].Bottom = SeamData[y, x].Right = adjustRange;
                    SeamData[y + 1, x].Left = SeamData[y + 1, x].Top = SeamData[y + 1, x].Bottom = SeamData[y + 1, x].Right = adjustRange;
                }
                else
                {
                    SeamData[y, x].Left = SeamData[y, x].Top = SeamData[y, x].Bottom = SeamData[y, x].Right = adjustRange;
                    SeamData[y - 1, x].Left = SeamData[y - 1, x].Top = SeamData[y - 1, x].Bottom = SeamData[y - 1, x].Right = adjustRange;
                }
                Draw();
            }
        }
    }
}
