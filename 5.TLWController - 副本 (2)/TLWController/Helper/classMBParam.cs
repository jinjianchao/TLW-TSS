using System;
using System.Collections.Generic;
using System.Text;

namespace TLWController.Helper
{
    /// <summary>
    /// 封装主板参数信息
    /// </summary>
    public class classMBParam
    {
        private byte[] m_dat;
        public classMBParam(byte[] src, int nOffset, int nLen)
        {
            m_dat = new byte[nLen];
            Array.Copy(src, nOffset, m_dat, 0, nLen);//复制数据
        }

        public bool Is60Hz
        {
            get
            {

                return (m_dat[36] == 0);
            }
        }

        public bool Is3D
        {
            get
            {
                return (m_dat[20] == 1);
            }
        }


    }
}
