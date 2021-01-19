using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Bogus.DataSets.Name;

namespace TelBook
{
   
    public class AddDataPerson
    {
        public enum Gender
        {
            Male,
            Female
        }

        public static void AddPerson(MyContext context)
        {
            var personId = 1;

            List<Person> person = new List<Person>();
             var p = new Faker<Person>("uk")
                .RuleFor(x => x.Id, f =>personId++)
                .RuleFor(x => x.Gender, f =>f.Person.Gender.ToString())
                .RuleFor(x => x.Name, f => f.Name.FirstName(f.Person.Gender))                
                .RuleFor(x => x.Surname, f=> f.Name.LastName(f.Person.Gender))
                .RuleFor(x => x.Number, f => f.Phone.PhoneNumber());

            for (int i = 0; i < 50; i++)
            {
                person.Add(p.Generate());
            }

            if (context.Persons.Count() == 0)
            {
                foreach (var item in person)
                {
                    context.Persons
                    .Add(
                    new Person
                    {
                        Id=item.Id,
                        Gender=item.Gender,
                        Name = item.Name,
                        Surname=item.Surname,
                        Number=item.Number
                        
                    });
                }
            }
            context.SaveChanges();
        }

    }
}
