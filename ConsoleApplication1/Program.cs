using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            new MyXml("ConsoleTestApplication.xml", @"C:\Users\stefaan.avonds\Source");

            Console.WriteLine("XML generated");
            Console.ReadLine();
        }
    }
}
