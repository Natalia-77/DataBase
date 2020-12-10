using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            Console.WriteLine("Added");
        }
     }
}
