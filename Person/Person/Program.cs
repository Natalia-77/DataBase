using System;


namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {          

            int action = 0;
            MyContext context = new MyContext();
            do
            {
                Console.WriteLine("0-Exit");
                Console.WriteLine("1-Show all");
                Console.WriteLine("2-Add to database");
                Console.WriteLine("3-Delete from database");
                Console.WriteLine("4-Edit");
                Console.WriteLine("5-Found");
                action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        {
                            foreach (var item in context.PersonsDetails)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            break;
                        }
                    case 2:
                        {
                            context.Addes();
                            break;
                        }
                    case 3:
                        {
                            context.Deleted();
                            break;
                        }
                    case 4:
                        {
                            context.Edited();
                            break;
                        }
                    case 5:
                        {
                            context.Founded();
                            break;
                        }

                }

            } while (action != 0);


        }

    }

}
