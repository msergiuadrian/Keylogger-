using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Keylogger
{
    public class RealDocument : DocumentInterface
    {
        const string pass = "parola";
        public string GetDocument(string docPath)
        {
            StreamReader sr = new StreamReader(docPath);
            string text = sr.ReadToEnd();
            return Cryptography.Encrypt(text, pass);
        }
    }
}
