using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


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

        public void Founded()
        {
            Console.WriteLine("1.Found by id");
            Console.WriteLine("2.Found by name(or couple letters)");
            Console.WriteLine("3.Found by point(male/female)");
            Console.WriteLine("4.Found by age");
            Console.WriteLine("5.Found by weight");

            int pos = int.Parse(Console.ReadLine());
            switch(pos)
            {
                case 1:
                    {
                        Console.WriteLine("Enter id:");
                        int ids = int.Parse(Console.ReadLine());
                        var res = (from Persons in PersonsDetails                                      
                                   where Persons.Id == ids                                   
                                   select Persons);

                        if (res.Count() > 0)
                        {
                            foreach (var item in res)
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not found person with these id!");
                            Console.WriteLine("-----------------");
                        }

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter name:");
                        string res2 = Console.ReadLine();
                        var res = (from Persons in PersonsDetails
                                   where Persons.Name.ToLower().Contains(res2)
                                   select Persons);

                        if (res.Count() > 0)
                        {
                            foreach (var item in res)
                            {
                                Console.WriteLine(item.ToString());
                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found person with these parametres!");
                            Console.WriteLine("-----------------");
                        }

                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter 1 for male list or enter 0 for female list");
                        byte sex = byte.Parse(Console.ReadLine());
                        var res = (from Persons in PersonsDetails
                                   where Persons.Point == sex
                                   select Persons);

                        if (res.Count() > 0)
                        {
                            foreach (var item in res)
                            {
                                Console.WriteLine(item.ToString());
                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found!");
                            Console.WriteLine("-----------------");
                        }

                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Enter age:");
                        int age = int.Parse(Console.ReadLine());
                        var res = (from Persons in PersonsDetails
                                   where Persons.Age == age
                                   select Persons);

                        if (res.Count() > 0)
                        {
                            foreach (var item in res)
                            {
                                Console.WriteLine(item.ToString());
                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found person with these age !");
                            Console.WriteLine("-----------------");
                        }

                        break;
                    }

                case 5:
                    {
                        Console.WriteLine("Enter weight:");
                        int weight = int.Parse(Console.ReadLine());
                        var res = (from Persons in PersonsDetails
                                   where Persons.Weight== weight
                                   select Persons);

                        if (res.Count() > 0)
                        {
                            foreach (var item in res)
                            {
                                Console.WriteLine(item.ToString());
                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found person with these weight!");
                            Console.WriteLine("-----------------");
                        }

                        break;
                    }

            }



        }
    }
}
