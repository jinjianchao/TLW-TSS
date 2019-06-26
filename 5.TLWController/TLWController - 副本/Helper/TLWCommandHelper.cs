#region << 注释 >>
/************************************************************************
*文件名： TLWCommand
*创建人： JIN
*创建时间：2019/6/3 12:18:06
*描述：
*=======================================================================
*修改时间：2019/6/3 12:18:06
*修改人：
*描述：
************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLWController.Helper
{
    public class ReturnParam
    {
        public string IP { get; set; }
        public int Dev { get; set; }
        public int ResultCode { get; set; }
    }

    public class TLWCommandHelper1
    {
        public void SetBrightness(Dictionary<string, int> devIP, ushort address, ushort id, ushort color, ushort r, ushort g, ushort b, Action<ReturnParam[]> action)
        {
            Task<ReturnParam[]> task = new Task<ReturnParam[]>(obj =>
            {
                object[] paramArr = obj as object[];
                Dictionary<string, int> ips = paramArr[0] as Dictionary<string, int>;
                ushort paramCardAddr = (ushort)paramArr[1];
                ushort paramId = (ushort)paramArr[2];
                ushort paramColor = (ushort)paramArr[3];
                ushort paramR = (ushort)paramArr[4];
                ushort paramG = (ushort)paramArr[5];
                ushort paramB = (ushort)paramArr[6];

                ReturnParam[] returnParam = new ReturnParam[ips.Count];
                int i = 0;
                foreach (var item in ips)
                {
                    new Task((index) =>
                    {
                        int cx = (int)index;
                        returnParam[cx] = new ReturnParam();
                        returnParam[cx].IP = item.Key;
                        returnParam[cx].Dev = item.Value;
                        //returnParam[cx].ResultCode = _TLWCommand.tlw_SetBrightness(item.Value, paramCardAddr, 0, color, r, g, b);
                    }, i, TaskCreationOptions.AttachedToParent).Start();
                    i++;
                }
                return returnParam;
            }, new object[] { devIP, address, id, color, r, g, b });

            task.ContinueWith(t =>
            {
                action(t.Result);
            });
            task.Start();
        }
    }
}
