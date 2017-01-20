using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    public class MyXml : XmlCreator.XmlCreator
    {
        public MyXml(string filename)
            : this(filename, String.Empty)
        {

        }

        public MyXml(string filename, string filepath)
            : base(filename, filepath)
        {

        }

        protected override XElement CreateDefaultXElement()
        {
            return new XElement("MySettings");
        }
    }
}
