using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Doctores
{

    public class AddData
    {

        public static List<int> GetDepartment()
        {
            MyContext context = new MyContext();
            List<int> IdList = new List<int>();
            var departm = context.Departments.Select(c => c.Id);
            foreach (var item in departm)
            {
                IdList.Add(item);
            }

            return IdList;
        }


        public static void AddDepartment(MyContext context)
        {
            List<Doctor> doc = new List<Doctor>();
            List<Department> dep = new List<Department>();
            Random rand = new Random();
            List<int> ID = GetDepartment();

            var department = new Faker<Department>("uk")
                   .RuleFor(x => x.Name, f => f.Lorem.Word())
                   .RuleFor(x => x.NumberCabinet, f => f.Random.Number(1, 50));

            var doctor = new Faker<Doctor>("uk")
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.Stage, f => f.Random.Number(10, 25))
                .RuleFor(x => x.DepartmentId, f => ID[rand.Next(1, ID.Count() - 1)]);

            //Департаментів 50 штук.
            for(int i=0;i<50;i++)
            {
                dep.Add(department.Generate());
            }
            //Лікарів 1000 осіб.
            for (int j = 0; j < 1000; j++)
            {                
                doc.Add(doctor.Generate());
            }


            if (context.Departments.Count() == 0)
            {
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
            }

            if (context.Doctors.Count()== 0)
            {
                foreach (var item in doc)
                {
                    context.Doctors
                        .Add(
                        new Doctor
                        {
                            LastName = item.LastName,
                            FirstName = item.FirstName,
                            Stage = item.Stage,
                            DepartmentId = item.DepartmentId
                        });
                }
            }

            context.SaveChanges();


        }
    }
}
