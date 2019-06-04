using System;
using Microsoft.Win32;
using System.IO.Ports;
using System.Net.Sockets;
using System.Net;

namespace LydTOPDP
{
   public class GlobalFun
    {
        /// <summary>
        /// 获取本机可用串口号
        /// </summary>
        /// <returns></returns>
        public static string[] GetCommKeys()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// 判断指定端口是否可用
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        private static  bool IsAvaliable(int port)
        {
            Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            bool result = false;
            try
            {
                sk.Bind(new IPEndPoint(IPAddress.Any, port));//尝试绑定，因为如果该端口已经被使用，则无法绑定，会导致异常
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                sk.Close();
            }
            return result;
        }

        /// <summary>
        /// 这个方法取得一个可用的端口
        /// </summary>
        /// <returns></returns>
        public static int GetAvaliablePort()
        {
            //Random rnd = new Random();
            //int port = rnd.Next(1024, 65535);//随机产生一个动态的端口号
            //while (!IsAvaliable(port))
            //{
            //    port = rnd.Next(1024, 65535);
            //}
            //return port;
            return 0;
        }


    }

   public class Constant
   {
       public static String LanguageConfig = @"Language\LanguageList.xml";
       public static String LanguageResource = @"Language\LanguageResource.xml";
       public static String LanguageResourcePath = @"Language";
       public static String LanText = @"Language\Lan.txt";
   }
}
