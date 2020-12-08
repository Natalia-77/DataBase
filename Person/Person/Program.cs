using System;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Persons person = new Persons();
            person.Name = "Oleg";
            person.Surname = "Petrov";
            person.Weight = 65;
            person.Age = 25;
            person.Footsize = 42;
            person.Point = 1;
            MyContext context = new MyContext();
            context.PersonsDetails.Add(person);
            context.SaveChanges();

        }
    }
}
