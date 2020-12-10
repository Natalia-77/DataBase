using System;
using System.Linq;

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
                                Console.WriteLine($"{ item.Id}. { item.Name} {item.Surname} --> {item.Age}   {item.Weight}   {item.Point}  {item.Footsize}");
                            }
                            break;
                        }
                    case 2:
                        {
                            //Persons person = new Persons();
                            //Console.WriteLine("Enter name :");
                            //person.Name = Console.ReadLine();
                            //Console.WriteLine("Enter name :");
                            //person.Surname = Console.ReadLine();
                            //Console.WriteLine("Enter weight :");
                            //person.Weight = int.Parse(Console.ReadLine());
                            //Console.WriteLine("Enter age :");
                            //person.Age = int.Parse(Console.ReadLine());
                            //Console.WriteLine("Enter footsize :");
                            //person.Footsize = int.Parse(Console.ReadLine());
                            //Console.WriteLine("Enter point :");
                            //person.Point = byte.Parse(Console.ReadLine());                          
                            //context.PersonsDetails.Add(person);
                            //context.SaveChanges();
                            //Console.WriteLine("Added");
                            context.Addes();

                            break;
                        }
                    case 3:
                        {
                            context.Deleted();

                            //Console.WriteLine("Enter id:");
                            //int id = int.Parse(Console.ReadLine());
                            //Persons d = context.PersonsDetails.SingleOrDefault(x => x.Id == id);
                            //if (d != null)
                            //{
                            //    context.PersonsDetails.Remove(d);
                            //}
                            //else
                            //{
                            //    Console.WriteLine($"Sorry,there is no element with-->{id}<-- id");
                            //}
                            //context.SaveChanges();

                            break;
                        }








                }//switch

            } while (action != 0);


        }//main

    }//program

}//namespace
