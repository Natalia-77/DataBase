using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Host
{
    public class MyContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=95.214.10.36;Port=5432;Database=natadb;Username=natalia;Password=$544$B77w**G)K$t!Ube22}77b");
        }
    }
}
