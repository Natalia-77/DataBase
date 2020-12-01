using Bogus;
using System;

using System.Text;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            //Randomizer.Seed = new Random();
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;  
            
            TableService tab = new TableService();

            tab.Create();
            tab.AddDataToTable();

        }
    }
}
