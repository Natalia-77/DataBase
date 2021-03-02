using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelBook
{
   public class MyContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseNpgsql("Server=95.214.10.36;Port=5432;Database=natadb;Username=natalia;Password=$544$B77w**G)K$t!Ube22}77b");
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=nataliadb;Username=natalia;Password=$544$B77w**G)K$t!Ube22}77b");
        }
    }
}
