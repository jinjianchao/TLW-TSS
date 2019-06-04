using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PluginLib.Data
{
    public class FormatData
    {
        public string HardwareVersion { get; set; }
        public string Version { get; set; }
        public string[] Formats { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("HardwareVersion:" + HardwareVersion + "\r\n");
            sb.Append("Version:" + Version + "\r\n");
            sb.Append("FormatData:\r\n");
            int count = 0;
            foreach (var item in Formats)
            {
                sb.Append("          【" + ++count + "】" + item.ToString() + "\r\n");
            }
            return sb.ToString();
        }
    }

    public class InfoData
    {
        public InfoData()
        {
            Titles = new List<string>();
            StateValue = new List<Hashtable>();
        }
        public IList<string> Titles { get; set; }
        public string Data { get; set; }
        public bool IsStateValue { get; set; }
        public IList<Hashtable> StateValue { get; set; }
        public string Command { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            foreach (var item in Titles)
            {
                string tmpData = "";
                if (IsStateValue)
                {
                    foreach (var itm in StateValue)
                    {
                        tmpData += itm[Data] + "(" + Data + ");";
                    }
                }
                else
                {
                    tmpData = Data;
                }
                sb.Append("【" + ++count + "】" + item.ToString() + ":" + tmpData + "\r\n");
            }
            return sb.ToString();
        }
    }

    public class ParamRowData
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string StrValue { get; set; }
        public string DataValue { get; set; }
        public string Command { get; set; }
    }
}

namespace PluginLib.Command
{
    public class CommandMethod
    {
        public string Command1(string arg1, int arg2)
        {
            return "Result From Command1:" + arg1 + "," + arg2;
        }

        public int Command2(int arg1, int arg2)
        {
            return arg1 + arg2;
        }

        public string Command3(string b)
        {
            return "No parameter method!";
        }
    }

    public class CommandList
    {
        public String Text { get; set; }
        public object Value { get; set; }

        public CommandList(String text, String value)
        {
            Text = text;
            Value = value;
        }
    }
}

namespace PluginLib.ExceptionEx
{
    [Serializable]
    public class CompareException : ApplicationException
    {
        public CompareException() { }
        public CompareException(string message) : base(message) { }
        public CompareException(string message, Exception inner) : base(message, inner) { }
    }
}

namespace PluginLib.Helper
{
    using PluginLib.Data;
    using System.IO;
    using System.Diagnostics;


    public class FormatDataHelper
    {
        string _file = string.Empty;
        public FormatDataHelper(string file)
        {
            _file = file;
        }

        string ReadValueByKey(string key)
        {
            string result = "";
            TextReader reader = new StreamReader(_file);
            try
            {
                string str = "";
                bool isFind = false;
                while ((str = reader.ReadLine()) != null)
                {
                    if (str.Equals(key))
                    {
                        result = reader.ReadLine();
                        if (key == "#format")
                        {
                            isFind = true;
                            if (result.StartsWith(";"))
                            {
                                result = "";
                            }
                        }
                        //break;
                    }
                    else if (isFind)
                    {
                        if (!str.StartsWith("#") && !str.StartsWith(";"))
                        {
                            if (result == "")
                            {
                                result = str;
                            }
                            else
                            {
                                result = result + "|" + str;
                            }
                        }
                        else if (str.StartsWith(";"))
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch
            { }
            finally
            {
                reader.Close();
                reader = null;
            }
            return result;
        }

        public FormatData ReadFormatData()
        {
            FormatData data = new FormatData();
            data.HardwareVersion = ReadValueByKey("#hardware");
            data.Version = ReadValueByKey("#version");
            data.Formats = ReadValueByKey("#format").Split('|');
            return data;
        }
    }

    public class ConvertHelper
    {
        string[] GetFormatItem(string format)
        {
            string[] formats = format.Split('[');
            for (int i = 0; i < formats.Length; i++)
            {
                formats[i] = formats[i].Replace("]", "");
            }
            string[] result = new string[formats.Length - 1];
            for (int i = 1; i < formats.Length; i++)
            {
                result[i - 1] = formats[i];
            }
            return result;
        }

        void GetDataRange(string data, out int start, out int end)
        {
            string[] tmp;
            if (data.Contains("-"))
            {
                tmp = data.Split('-');
                start = int.Parse(tmp[0]);
                end = int.Parse(tmp[1]);
                Debug.WriteLine("[" + (start - 25) + "-" + (end - 25) + "]");
            }
            else
            {
                start = int.Parse(data);
                end = int.Parse(data);
                Debug.WriteLine("[" + (start - 25) + "]");
            }
        }

        struct BitDataRange
        {
            public int start;
            public int end;

            public BitDataRange(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }

        BitDataRange GetBitRange(string str)
        {
            //[117-118][#2(0-4)][0][50Hz红色电流][][-1][none][]
            int cutbitStart = str.LastIndexOf("(") + 1;
            int cutbitLen = str.LastIndexOf(")") - cutbitStart;
            string bitStr = str.Substring(cutbitStart, cutbitLen);
            string[] bitStrArr = bitStr.Split('-');
            int bitStart = int.Parse(bitStrArr[0]);
            int bitEnd = int.Parse(bitStrArr[1]);
            return new BitDataRange(bitStart, bitEnd);
        }



        InfoData Convert(byte[] data, string format)
        {
            InfoData result = new InfoData();
            string[] formats = GetFormatItem(format);
            bool isBitData = false;
            string byteLen = formats[1].Replace("#", "").Split('(')[0];
            if (formats[1].StartsWith("#"))//位数据
            {
                isBitData = true;

            }
            //是否使用自定义字符串
            bool needCustomStr = false;
            if (formats.Length == 9)
            {
                if (formats[8] != "")
                {
                    needCustomStr = true;
                }
            }

            if (int.Parse(byteLen) == 1)//单字节数据
            {
                int start = 0, end = 0;
                GetDataRange(formats[0], out start, out end);

                string tmpData = "";
                for (int i = start; i <= end; i++)
                {
                    tmpData += data[i] + formats[4];
                }
                result.Data = (tmpData.EndsWith(formats[4]) && !string.IsNullOrEmpty(formats[4]) ? tmpData.Substring(0, tmpData.Length - 1) : tmpData);
                if (isBitData)
                {
                    BitDataRange bitRange = GetBitRange(formats[1]);
                    UInt16 tmp1 = (UInt16)(UInt16.Parse(result.Data) << (8 - (bitRange.end + 1)));
                    result.Data = (tmp1 >> (8 - (bitRange.end - bitRange.start + 1))).ToString();
                }
                string[] lans = formats[3].Split('#');
                foreach (var item in lans)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    result.Titles.Add(item);
                }

                result.IsStateValue = formats[5] == "0" ? true : false;
                if (result.IsStateValue)
                {
                    string[] tmpStatevalues = formats[6].Split('#');
                    for (int i = 0; i < tmpStatevalues.Length; i++)
                    {
                        tmpStatevalues[i] = tmpStatevalues[i].Replace("(", "").Replace(")", "");
                    }
                    for (int i = 0; i < tmpStatevalues.Length; i++)
                    {
                        Hashtable hs = new Hashtable();
                        string[] tmpValue = tmpStatevalues[i].Split(';');
                        for (int j = 0; j < tmpValue.Length; j++)
                        {
                            string[] tmp = tmpValue[j].Split(':');
                            hs.Add(tmp[0], tmp[1]);
                        }
                        result.StateValue.Add(hs);
                    }
                }
                result.Command = formats[7];
            }
            else if (int.Parse(byteLen) == 2)//双字节数据
            {
                int start = 0, end = 0;
                GetDataRange(formats[0], out start, out end);

                IList<UInt16> worddata = new List<UInt16>();
                string tmpData = "";
                for (int i = start; i <= end; i += 2)
                {
                    byte[] tmpByte = new byte[2];
                    if (int.Parse(formats[2]) == 0)//高位在前，地位在后
                    {
                        tmpByte[0] = data[i + 1];
                        tmpByte[1] = data[i];
                    }
                    else if (int.Parse(formats[2]) == 1)//地位在前，高位在后
                    {
                        tmpByte[0] = data[i];
                        tmpByte[1] = data[i + 1];
                    }
                    worddata.Add(BitConverter.ToUInt16(tmpByte, 0));
                    tmpData += BitConverter.ToUInt16(tmpByte, 0) + formats[4];
                }
                result.Data = (tmpData.EndsWith(formats[4]) && !string.IsNullOrEmpty(formats[4]) ? tmpData.Substring(0, tmpData.Length - 1) : tmpData);
                if (isBitData)
                {
                    BitDataRange bitRange = GetBitRange(formats[1]);
                    UInt16 tmp1 = (UInt16)(UInt16.Parse(result.Data) << (16 - (bitRange.end + 1)));
                    result.Data = (tmp1 >> (16 - (bitRange.end - bitRange.start + 1))).ToString();
                }
                if (needCustomStr)
                {
                    //ComputeStr={65535*x/100}|ComputeValue={0}|Result={Compute%(R="arg0",G="arg1",B="arg2")}
                    string[] computeDateData = formats[8].Split('$');
                    string str = "";
                    foreach (string item in computeDateData)
                    {
                        if (item.Contains("ComputeStr"))
                        {
                            string ComputeValue = Array.Find<string>(computeDateData, p => p.Contains("ComputeValue")).Replace("ComputeValue={", "").Replace("}", "");
                            Int32 computeVal = worddata[int.Parse(ComputeValue)];
                            string computeStr = Array.Find<string>(computeDateData, p => p.Contains("ComputeStr")).Replace("ComputeStr={", "").Replace("}", "").Replace("x", computeVal.ToString());
                            computeVal = (Int32)Math.Round(float.Parse((new System.Data.DataTable().Compute(computeStr, "")).ToString()));
                            str = Array.Find<string>(computeDateData, p => p.Contains("Result")).Replace("Result={", "").Replace("}", "");
                            str = str.Replace("Compute", computeVal.ToString());
                            for (int i = 0; i < worddata.Count; i++)
                            {
                                string tmpStr = Array.Find<string>(computeDateData, p => p == "arg" + i);
                                if (str.Contains("arg" + i))
                                {
                                    str = str.Replace("arg" + i, worddata[i].ToString());
                                }
                            }
                        }
                    }
                    result.Data = str;

                }
                string[] lans = formats[3].Split('#');
                foreach (var item in lans)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    result.Titles.Add(item);
                }

                result.IsStateValue = formats[5] == "0" ? true : false;
                if (result.IsStateValue)
                {
                    string[] tmpStatevalues = formats[6].Split('#');
                    for (int i = 0; i < tmpStatevalues.Length; i++)
                    {
                        tmpStatevalues[i] = tmpStatevalues[i].Replace("(", "").Replace(")", "");
                    }
                    for (int i = 0; i < tmpStatevalues.Length; i++)
                    {
                        Hashtable hs = new Hashtable();
                        string[] tmpValue = tmpStatevalues[i].Split(';');
                        for (int j = 0; j < tmpValue.Length; j++)
                        {
                            string[] tmp = tmpValue[j].Split(':');
                            hs.Add(tmp[0], tmp[1]);
                        }
                        result.StateValue.Add(hs);
                    }
                }
                result.Command = formats[7];
            }
            else if (int.Parse(byteLen) == 4)//四字节数据
            {
                int start = 0, end = 0;
                GetDataRange(formats[0], out start, out end);

                string tmpData = "";
                for (int i = start; i <= end; i += 2)
                {
                    byte[] tmpByte = new byte[4];
                    if (int.Parse(formats[2]) == 0)//高位在前，地位在后
                    {
                        tmpByte[0] = data[i + 3];
                        tmpByte[1] = data[i + 2];
                        tmpByte[2] = data[i + 1];
                        tmpByte[3] = data[i];
                    }
                    else if (int.Parse(formats[2]) == 1)//地位在前，高位在后
                    {
                        tmpByte[0] = data[i];
                        tmpByte[1] = data[i + 1];
                        tmpByte[2] = data[i + 2];
                        tmpByte[3] = data[i + 3];
                        tmpByte[4] = data[i + 4];
                    }
                    tmpData += BitConverter.ToUInt32(tmpByte, 0) + formats[4];
                }
                result.Data = (tmpData.EndsWith(formats[4]) && !string.IsNullOrEmpty(formats[4]) ? tmpData.Substring(0, tmpData.Length - 1) : tmpData);
                if (isBitData)
                {
                    BitDataRange bitRange = GetBitRange(formats[1]);
                    UInt16 tmp1 = (UInt16)(UInt16.Parse(result.Data) << (32 - (bitRange.end + 1)));
                    result.Data = (tmp1 >> (32 - (bitRange.end - bitRange.start + 1))).ToString();
                }
                string[] lans = formats[3].Split('#');
                foreach (var item in lans)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    result.Titles.Add(item);
                }

                result.IsStateValue = formats[5] == "0" ? true : false;
                if (result.IsStateValue)
                {
                    string[] tmpStatevalues = formats[6].Split('#');
                    for (int i = 0; i < tmpStatevalues.Length; i++)
                    {
                        tmpStatevalues[i] = tmpStatevalues[i].Replace("(", "").Replace(")", "");
                    }
                    for (int i = 0; i < tmpStatevalues.Length; i++)
                    {
                        Hashtable hs = new Hashtable();
                        string[] tmpValue = tmpStatevalues[i].Split(';');
                        for (int j = 0; j < tmpValue.Length; j++)
                        {
                            string[] tmp = tmpValue[j].Split(':');
                            hs.Add(tmp[0], tmp[1]);
                        }
                        result.StateValue.Add(hs);
                    }
                }
                result.Command = formats[7];
            }
            else if (int.Parse(byteLen) == 8)//八字节数据
            {

            }

            return result;
        }

        public IList<ParamRowData> ConverToInfoGridData(byte[] data, FormatData info)
        {
            IList<ParamRowData> result = new List<ParamRowData>();
            for (int i = 0; i < info.Formats.Length; i++)
            {
                ParamRowData infoData = new ParamRowData();
                InfoData iData = Convert(data, info.Formats[i]);
                infoData.ID = i + 1;
                infoData.Key = iData.Titles[0];
                if (iData.IsStateValue)
                {
                    if (iData.StateValue[0].ContainsKey(iData.Data))
                    {
                        infoData.StrValue = iData.StateValue[0][iData.Data].ToString();
                    }
                    else
                    {
                        infoData.StrValue = iData.Data;
                    }
                }
                else
                {
                    infoData.StrValue = iData.Data;
                }
                infoData.DataValue = iData.Data;
                result.Add(infoData);
            }
            return result;
        }
    }
}

