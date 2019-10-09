using System;
using System.Collections.Generic;
using System.Text;

namespace UnitInfo
{
    #region 结构
    //箱体子类型
    public class UnitSubType
    {
        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        String _name;
        /// <summary>
        /// 型号
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        int _unitSizeH;
        public int UnitSizeH
        {
            get { return _unitSizeH; }
            set { _unitSizeH = value; }
        }

        int _unitSizeV;
        public int UnitSizeV
        {
            get { return _unitSizeV; }
            set { _unitSizeV = value; }
        }

        int _BoardPixelH;

        public int BoardPixelH
        {
            get { return _BoardPixelH; }
            set { _BoardPixelH = value; }
        }

        int _BoardPixelV;

        public int BoardPixelV
        {
            get { return _BoardPixelV; }
            set { _BoardPixelV = value; }
        }


        public int UnitPixelH
        {
            get { return _BoardPixelH * UnitSizeH; }
        }


        public int UnitPixelV
        {
            get { return _BoardPixelV * UnitSizeV; }
        }

        int bit = 8;//8-8bit,10-10bit
        public int Bit
        {
            get { return bit; }
            set { bit = value; }
        }

        IList<UnitSubType> _subType = new List<UnitSubType>();
        public IList<UnitSubType> SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }

        /// <summary>
        /// 每个连接板连接的灯板数量
        /// </summary>
        public int ConnectModuleCount { get; set; }
    }
    //箱体类型
    public class UnitMainType
    {
        int _id;
        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        String _name;
        /// <summary>
        /// 型号名称
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _title;
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Serial { get; set; }

        IList<UnitSubType> _subType = new List<UnitSubType>();
        /// <summary>
        /// 子类型
        /// </summary>
        public IList<UnitSubType> SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class UnitSerialType
    {
        public string Name { get; set; }

        public string Title { get; set; }
    }
    #endregion
}
