using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Doctors
{
    public static class AddData
    {
        public static void AddDepartment(MyContext context)
        {
            List<Doctor> doc = new List<Doctor>();
            List<Department> dep = new List<Department>();
            Random rand = new Random();
            //if (context.Departments.Count() == 0)
            // {
            var department = new Faker<Department>("uk")
                   .RuleFor(x => x.Name, f => f.Name.FirstName())
                   .RuleFor(x => x.NumberCabinet, f => f.Random.Number(1, 2000));

            var doctor = new Faker<Doctor>("uk")
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.Stage, f => f.Random.Number(10, 25))
                .RuleFor(x => x.DepartmentId, f => f.Random.Number(1, 1000));

            for (int i = 0; i < 100; i++)
            {
                // context.Departments.Add(department.Generate());
                //context.Doctors.Add(doctor.Generate());
                dep.Add(department.Generate());
                doc.Add(doctor.Generate());

                //}

                //if (context.Departments.Count() == 0)
               // {
                    foreach (var item in dep)
                    {
                        context.Departments
                        .Add(
                        new Department
                        {
                            Name = item.Name,
                            NumberCabinet = item.NumberCabinet
                        });
                    }
                //}

                //if(context.Doctors.Count()==0)
                // {
                //foreach (var item in doc)
                //{
                //    context.Doctors
                //        .Add(
                //        new Doctor
                //        {
                //            LastName=item.LastName,
                //            FirstName=item.FirstName,
                //            Stage=item.Stage,
                //            DepartmentId=item.DepartmentId
                //        });
                //}
                //}

                context.SaveChanges();

            }
        }
    }
}
