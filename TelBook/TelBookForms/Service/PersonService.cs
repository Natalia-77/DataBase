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
        public static PersonItemModel Search(MyContext context,Search search)
        {

            PersonItemModel personmod = new PersonItemModel();
            int showitems = 7;
            //int _page = 1;
            var query = context.Persons.AsQueryable();
            if(!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }
            if (!string.IsNullOrEmpty(search.Surname))
            {
                query = query.Where(x => x.Surname.Contains(search.Surname));
            }
            if (!string.IsNullOrEmpty(search.Telephone))
            {
                query = query.Where(x => x.Surname.Contains(search.Telephone));
            }
            int page = search.Page - 1;
            personmod.CountRows = query.Count();
            personmod.Persons = query
                .OrderBy(x=>x.Id)
                .Skip(page*showitems)
                .Take(showitems)
                .Select(x => new PersonItemView           
            {
                //PersonId=x.Id,
                Surname=x.Surname,
                Name=x.Name,
                Telephone = x.Number,
                Gen =x.Gender                

            }).ToList();

            return personmod;
        }

    }
}
