using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace PluginLib
{
    public class DllHelper
    {

        [DllImport("kernel32.dll")]

        private extern static IntPtr LoadLibrary(String path);

        [DllImport("kernel32.dll")]

        private extern static IntPtr GetProcAddress(IntPtr lib, String funcName);

        [DllImport("kernel32.dll")]

        private extern static bool FreeLibrary(IntPtr lib);

        private IntPtr hLib;

        public DllHelper(String DLLPath)
        {

            hLib = LoadLibrary(DLLPath);
        }

        ~DllHelper()
        {

            FreeLibrary(hLib);

        }

        //将要执行的函数转换为委托
        //APIName:DLL中函数名称
        // T:委托名
        public Delegate Invoke(String APIName, Type t)
        {
            Delegate del = null;
            try
            {
                IntPtr api = GetProcAddress(hLib, APIName);
                del = (Delegate)Marshal.GetDelegateForFunctionPointer(api, t);
            }
            catch
            {
            }

            return del;

        }

    }
}
