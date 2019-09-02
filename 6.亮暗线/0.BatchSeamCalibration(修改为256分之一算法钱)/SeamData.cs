#region << 注释 >>
/************************************************************************
*文件名： SeamData
*创建人： JIN
*创建时间：2018/12/19 13:42:10
*描述：
*=======================================================================
*修改时间：2018/12/19 13:42:10
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BatchSeamCalibration
{
    public struct SelectedBorder
    {
        public int[,] Left { get; set; }
        public int[,] Top { get; set; }
        public int[,] Right { get; set; }
        public int[,] Bottom { get; set; }
    }

    //public class SeamItemData
    //{
    //    public float Left { get; set; }
    //    public float Top { get; set; }
    //    public float Right { get; set; }
    //    public float Bottom { get; set; }
    //    public float Center { get { return 100; } }

    //    public Rectangle RectangleAll { get; set; }

    //    public Rectangle RectangleLeft { get; set; }

    //    public Rectangle RectangleTop { get; set; }

    //    public Rectangle RectangleRight { get; set; }

    //    public Rectangle RectangleBottom { get; set; }

    //    public List<Point> AreaLineLeft { get; set; }

    //    public List<Point> AreaLineTop { get; set; }
    //    public List<Point> AreaLineRight { get; set; }
    //    public List<Point> AreaLineBottom { get; set; }

    //    public List<Point> PreviewLineLeft { get; set; }
    //    public List<Point> PreviewLineTop { get; set; }
    //    public List<Point> PreviewLineRight { get; set; }
    //    public List<Point> PreviewLineBottom { get; set; }

    //    public SeamItemData(float defaultValue = 100)
    //    {
    //        Left = Top = Right = Bottom = defaultValue;
    //        AreaLineLeft = new List<Point>();
    //        AreaLineTop = new List<Point>();
    //        AreaLineRight = new List<Point>();
    //        AreaLineBottom = new List<Point>();
    //        PreviewLineLeft = new List<Point>();
    //        PreviewLineTop = new List<Point>();
    //        PreviewLineRight = new List<Point>();
    //        PreviewLineBottom = new List<Point>();
    //    }
    //}
}
