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
            int action = 0;
            do
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Show");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Search");
                Console.Write("--->");

                action = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (action)
                {
                    case 1:
                        {
                            var list = act.Show();
                            foreach (var item in list)
                            {
                                Console.WriteLine(item);
                            }
                          
                           
                            break;
                        }
                    case 2:
                        {
                            act.AddToTable();

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter Id for delete");
                            int id = int.Parse(Console.ReadLine());
                            act.Delete(id);
                            
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Id");
                            int ids = int.Parse(Console.ReadLine());
                            act.Update(ids);
                           
                            break;
                        }
                    case 5:
                        {

                            Search search = new Search();
                            Console.Write("Enter Product name: ");
                            search.ProductName = Console.ReadLine();
                            var reslist = act.Found(search);
                            foreach (var item in reslist)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }


                }
            } while (action != 0);

           
           

        }
    }
}
