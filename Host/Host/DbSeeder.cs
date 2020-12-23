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
            if (context.Departments.Count() == 0)
            {
                context.Departments
                    .Add(
                    new Department
                    {
                        Name = "Stomatology",
                        NumberCabinet = 160
                    });

                context.Departments
                    .Add(
                    new Department
                    {
                        Name = "Death-Note",
                        NumberCabinet = 161
                    });

                context.Departments
                   .Add(
                   new Department
                   {
                       Name = "Cardiology",
                       NumberCabinet = 162
                   });

                context.Departments
                   .Add(
                   new Department
                   {
                       Name = "Psychiatry",
                       NumberCabinet = 163
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
                            //Image                            
                            Department = context.Departments
                            .FirstOrDefault(x => x.Name == "Stomatology"),
                            Stage = 20
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
                            Department = context.Departments
                            .FirstOrDefault(x => x.Name == "Psychiatry"),
                            Stage = 8
                        });


                       context.Doctors
                        .Add(
                        new Doctor
                        {
                            LastName = "Mata",
                            FirstName = "Hary",
                            Login = "mata",
                            Password = Codify.HashPassword("985"),
                            //Image
                            Department = context.Departments
                            .FirstOrDefault(x => x.Name == "Cardiology"),
                            Stage = 12
                        });

                          context.Doctors
                        .Add(
                        new Doctor
                        {
                            LastName = "Lenin",
                            FirstName = "Ulianov",
                            Login = "lele",
                            Password = Codify.HashPassword("554"),
                            //Image
                            Department = context.Departments
                            .FirstOrDefault(x => x.Name == "Death-Note"),
                            Stage = 8
                        });




                context.SaveChanges();
                }
            }

    }
}
