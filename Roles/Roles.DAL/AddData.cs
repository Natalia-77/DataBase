using Roles.DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roles.DAL
{
    public class AddData
    {
        public static void Add(MyContext context)
        {
            AddUser(context);
            AddRoles(context);
            AddUserRoles(context);
        }

        private static void AddUser(MyContext context)
        {
            if (context.Users.Count() == 0)
            {
                context.Users
                    .Add(new User
                    {
                        Name = "Роман",
                        Surname = "Петрушка",
                        Login = "roma",
                        Password = PassHash.HashPassword("123")
                    });
                context.Users
                    .Add(new User
                    {
                        Name = "Петро",
                        Surname = "Макушка",
                        Login = "pet",
                        Password = PassHash.HashPassword("147")
                    });
                context.Users
                    .Add(new User
                    {
                        Name = "Маша",
                        Surname = "Мала",
                        Login = "mash",
                        Password = PassHash.HashPassword("258")
                    });
                context.Users
                  .Add(new User
                  {
                      Name = "Юля",
                      Surname = "Тимошенко",
                      Login = "yulia",
                      Password = PassHash.HashPassword("963")
                  });
                context.SaveChanges();
            }
        }

        private static void AddRoles(MyContext context)
        {
            if (context.Roles.Count() == 0)
            {
                context.Roles
                    .Add(new Role
                    {
                        Name = "Системний адміністратор"
                    });
                context.Roles
                    .Add(new Role
                    {
                        Name = ".Net Developer"
                    });
                context.Roles
                    .Add(new Role
                    {
                        Name = "QA Engeneer"
                    });
                context.Roles
                    .Add(new Role
                    {
                        Name = "Junior Python Developer"
                    });
                context.SaveChanges();
            }
        }
        private static void AddUserRoles(MyContext context)
        {
            if (context.UserRoles.Count() == 0)
            {
                context.UserRoles
                    .Add(new UserRoles
                    {
                        UserId = 1,
                        RoleId = 2,
                    });
                context.UserRoles
                    .Add(new UserRoles
                    {
                        UserId = 2,
                        RoleId = 3,
                    });
                context.UserRoles
                    .Add(new UserRoles
                    {
                        UserId = 3,
                        RoleId = 2,
                    });
                context.UserRoles
                    .Add(new UserRoles
                    {
                        UserId = 4,
                        RoleId = 1,
                    });
                context.UserRoles
                   .Add(new UserRoles
                   {
                       UserId = 3,
                       RoleId = 1,
                   });
                context.UserRoles
                   .Add(new UserRoles
                   {
                       UserId = 2,
                       RoleId = 1,
                   });

                context.SaveChanges();
            }

        }
    }
}
