using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Person
{
     public class MyContext:DbContext
     {
        public DbSet<Persons> PersonsDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseNpgsql("Server=95.214.10.36;Port=5432;Database=natadb;Username=natalia;Password=$544$B77w**G)K$t!Ube22}77b");

        public void Addes()
        {
            Persons person = new Persons();
            Console.WriteLine("Enter name :");
            person.Name = Console.ReadLine();
            Console.WriteLine("Enter name :");
            person.Surname = Console.ReadLine();
            Console.WriteLine("Enter weight :");
            person.Weight = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter age :");
            person.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter footsize :");
            person.Footsize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter point :");
            person.Point = byte.Parse(Console.ReadLine());
            PersonsDetails.Add(person);
            SaveChanges();
            Console.WriteLine(" Succsessfull added into database !");
        }
        public void Deleted()
        {
            Console.WriteLine("Enter id:");
            int id = int.Parse(Console.ReadLine());
            Persons d = PersonsDetails.SingleOrDefault(x => x.Id == id);
            if (d != null)
            {
                PersonsDetails.Remove(d);
            }
            else
            {
                Console.WriteLine($"Sorry,there is no element with--> {id} <-- id");
            }
            SaveChanges();

        }

        public void Edited()
        {
            Console.WriteLine("Enter id:");
            int id = int.Parse(Console.ReadLine());
            Persons p = PersonsDetails.SingleOrDefault(x => x.Id == id);
            if (p != null)
            {
                int choice = 0;
                Console.WriteLine("1.Edit name");
                Console.WriteLine("2.Edit surname");
                Console.WriteLine("3.Edit age");
                Console.WriteLine("4.Edit weight");
                Console.WriteLine("5.Edit footsize");
                Console.WriteLine("6.Edit point");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter new name:");
                            p.Name = Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter new surname:");
                            p.Surname = Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter new age:");
                            p.Age = int.Parse( Console.ReadLine());
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter new weight:");
                            p.Weight = int.Parse(Console.ReadLine());
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter new footsize:");
                            p.Footsize = int.Parse(Console.ReadLine());
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter new point:");
                            p.Point = byte.Parse(Console.ReadLine());
                            break;
                        }

                }
               
            }
            else
            {
                Console.WriteLine($"Sorry,there is no element with--> {id} <-- id");
            }
            SaveChanges();
        }
    }
}
