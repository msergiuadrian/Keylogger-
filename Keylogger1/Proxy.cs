using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keylogger
{
    public class Proxy : DocumentInterface
    {
        private RealDocument _realDocument = new RealDocument();
      public string GetDocument(string docPath)
        {
            return Cryptography.Decrypt(_realDocument.GetDocument(docPath), "parola");
        }
    }
    //blabla
}
