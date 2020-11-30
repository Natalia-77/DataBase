using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Create c = new Create();
            Fake n = new Fake();
             n.Print();
            



        }
    }
}
