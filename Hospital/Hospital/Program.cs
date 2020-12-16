using Hospital.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
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
                switch(action)
                {
                    case 1:
                        {
                            foreach (var item in context.Departments)
                            {
                                Console.WriteLine($"{ item.Id} { item.Name}");
                            }
                            break;
                        }
                    case 2:
                        {
                            Department d = new Department();
                            Console.WriteLine("Enter of departments:");
                            d.Name = Console.ReadLine();
                            //d.Name = "Surgery";
                            context.Departments.Add(d);
                            context.SaveChanges();
                            Console.WriteLine($"Added id={d.Id}");
                            break;
                        }
                    case 3:
                        {
                            
                            Console.WriteLine("Enter id:");
                            int id = int.Parse(Console.ReadLine());
                            Department d =context.Departments.SingleOrDefault(x=>x.Id==id);
                            if (d != null)
                            {
                                context.Departments.Remove(d);
                            }
                            else
                            {
                                Console.WriteLine($"Sorry,there is no element with-->{id}<-- id");
                            }
                            context.SaveChanges();                          

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter id:");
                            int id = int.Parse(Console.ReadLine());
                            Department d = context.Departments.SingleOrDefault(x => x.Id == id);
                            if (d != null)
                            {
                                Console.WriteLine("Enter new name");
                                d.Name = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"Sorry,there is no element with-->{id}<-- id");
                            }                           
                            context.SaveChanges();

                            break;

                        }
                    case 5:
                        {
                            
                            Console.WriteLine("Enter id:");
                            int ids = int.Parse(Console.ReadLine());
                            var res = (from Department in context.Departments
                                          where Department.Id == ids
                                          select Department.Name);

                            foreach (var item in res)
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
