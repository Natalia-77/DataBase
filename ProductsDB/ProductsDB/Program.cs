using System;
using System.Text;


namespace ProductsDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            TableAction act = new TableAction();

           

            var list=act.Show();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------\n");

            act.AddToTable();


        }
    }
}
