using Microsoft.EntityFrameworkCore;
using Posts.DAL;
using System;

namespace Posts
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            MyContext context = new MyContext();
            do
            {
                Console.WriteLine("1.tblCategory");
                Console.WriteLine("2.tblPost");
                Console.WriteLine("3.tblTag");
                Console.WriteLine("4.tblPostTag");
                Console.WriteLine("5.Exit");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            foreach (var item in context.Categories.Include(x => x.Posts))
                            {
                                Console.WriteLine($"{item.Name}--> {item.Description}");
                            }
                            break;
                        }
                    case 2:
                        {
                            foreach (var item in context.Posts.Include(x => x.Category))
                            {
                                Console.WriteLine($"{item.Title}--> {item.ShortDescription}- {item.PostedOn} {item.Category.Name}");
                            }
                            break;
                        }
                    case 3:
                        {
                            foreach (var item in context.Tags.Include(x => x.PostTags))
                            {
                                Console.WriteLine($"{item.Name}--> {item.Description}");
                            }
                            break;
                        }
                    case 4:
                        {
                            foreach (var item in context.PostTags.Include(x => x.Post))
                            {
                                Console.WriteLine($"{item.PostId}--> {item.TagId}");
                            }
                            break;
                        }


                }
            } while (choice != 5);
           
        }
    }
}
