
using System;

using System.Text;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;  
            
            TableService tab = new TableService();

            tab.Create();
            tab.AddDataToTable();

          

        }
    }
}
