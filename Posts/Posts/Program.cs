using Microsoft.EntityFrameworkCore;
using System;

namespace Posts
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MyContext context = new MyContext();
            foreach (var item in context.Posts.Include(x=>x.Category))
            {
                Console.WriteLine($"{item.Title}");
            }
        }
    }
}
