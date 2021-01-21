using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelBook;
using TelBookForms.Model;

namespace TelBookForms.PersonRead
{
    public class PersonService
    {
        public static List<PersonItemView> Search(MyContext context,Search search)
        {
            var query = context.Persons.AsQueryable();
            if(!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }
            if (!string.IsNullOrEmpty(search.Surname))
            {
                query = query.Where(x => x.Surname.Contains(search.Surname));
            }

            var list = query.Select(x => new PersonItemView
            //context.Persons.Select(x => new PersonItemView
            {
                //PersonId=x.Id,
                Surname=x.Surname,
                Name=x.Name,
                Telephone = x.Number,
                Gen =x.Gender                

            }).ToList();

            return list;
        }

    }
}
