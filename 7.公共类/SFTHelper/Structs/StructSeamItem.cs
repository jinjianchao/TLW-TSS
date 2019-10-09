#region << 注释 >>
/************************************************************************
*文件名： StructSeamItem
*创建人： JIN
*创建时间：2019/8/8 10:28:50
*描述：
*=======================================================================
*修改时间：2019/8/8 10:28:50
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SFTHelper.Structs
{
    public struct StructSeamItem
    {
        public float Left { get; set; }
        public float Top { get; set; }
        public float Right { get; set; }
        public float Bottom { get; set; }
        public float Center { get; set; }

        public Rectangle RectangleAll { get; set; }

        public Rectangle RectangleLeft { get; set; }

        public Rectangle RectangleTop { get; set; }

        public Rectangle RectangleRight { get; set; }

        public Rectangle RectangleBottom { get; set; }

        public List<Point> AreaLineLeft { get; set; }

        public List<Point> AreaLineTop { get; set; }
        public List<Point> AreaLineRight { get; set; }
        public List<Point> AreaLineBottom { get; set; }

        public List<Point> PreviewLineLeft { get; set; }
        public List<Point> PreviewLineTop { get; set; }
        public List<Point> PreviewLineRight { get; set; }
        public List<Point> PreviewLineBottom { get; set; }

        public StructSeamItem(float defaultValue = 100)
        {
            Left = Top = Right = Bottom = Center = defaultValue;
            RectangleAll = new Rectangle();
            RectangleLeft = new Rectangle();
            RectangleTop = new Rectangle();
            RectangleRight = new Rectangle();
            RectangleBottom = new Rectangle();
            AreaLineLeft = new List<Point>();
            AreaLineTop = new List<Point>();
            AreaLineRight = new List<Point>();
            AreaLineBottom = new List<Point>();
            PreviewLineLeft = new List<Point>();
            PreviewLineTop = new List<Point>();
            PreviewLineRight = new List<Point>();
            PreviewLineBottom = new List<Point>();
        }
    }
}
