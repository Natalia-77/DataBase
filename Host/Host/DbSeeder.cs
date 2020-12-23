using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host
{
    public static class DbSeeder
    {
        public static void SeedAll(MyContext context)
        {
            SeedDepatrment(context);
            SeedDoctor(context);
        }

        private static void SeedDepatrment(MyContext context)
        {
            if (context.Departments.Count() > 0)
            {
                context.Departments
                    .Add(
                    new Department
                    {
                        Name = "Stomatology",
                        NumberCabinet = 161
                    });

                context.Departments
                    .Add(
                    new Department
                    {
                        Name = "Death-Note",
                        NumberCabinet = 162
                    });
                context.SaveChanges();
            }
        }

            private static void SeedDoctor(MyContext context)
            {
                if (context.Doctors.Count() == 0)
                {
                    context.Doctors
                        .Add(
                        new Doctor
                        {
                            LastName = "Roberto",
                            FirstName = "Robertos",
                            Login = "roro",
                            Password = Codify.HashPassword("147"),
                            Stage = 20,
                            Department = context.Departments
                            .FirstOrDefault(x => x.Name == "Stomatology")
                        });

                    context.Doctors
                        .Add(
                        new Doctor
                        {
                            LastName = "Hose",
                            FirstName = "Garsia",
                            Login = "hoho",
                            Password = Codify.HashPassword("852"),
                            //Image
                            Stage = 8,
                            Department = context.Departments
                            .FirstOrDefault(x => x.Name == "Death-Note")
                        });


                    context.SaveChanges();
                }
            }

    }
}
