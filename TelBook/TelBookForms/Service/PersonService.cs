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
            ///Ствоємо екземпляр класа,в якому міститься Ліст Персонів.
            PersonItemModel personmod = new PersonItemModel();

            //Передається кількість відображуваних елементів,вказаних в комбобоксі.Обране користувачем.
            int showitems = search.CountPage;
            //int _page = 1;

            //Запит до Бази Даних.
            var query = context.Persons.AsQueryable();

            //Якщо поле Name для внесення даних для пошуку не порожнє,то виконується запит.
            if(!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }
            //Якщо поле Surname для внесення даних для пошуку не порожнє,то виконується запит.
            if (!string.IsNullOrEmpty(search.Surname))
            {
                query = query.Where(x => x.Surname.Contains(search.Surname));
            }
            //Якщо поле Telephone для внесення даних для пошуку не порожнє, то виконується запит.
            if (!string.IsNullOrEmpty(search.Telephone))
            {
                query = query.Where(x => x.Surname.Contains(search.Telephone));
            }

            int page = search.Page - 1;

            //Загальна кількість отриманих персонів дорівнює кількості елементів,отриманих в квері,щляхом запитів.
            personmod.CountRows = query.Count();

            //Додаємо в Ліст отримані дані,на основі запитів;Відображаємо їх виведення на форму,відповідно до
            //вказаної кількості одночасного відображення(7 позицій).
            personmod.Persons = query
                .OrderBy(x=>x.Id)
                .Skip(page*showitems)
                .Take(showitems)
                .Select(x => new PersonItemView           
            {     
            //Виводимо на форму вказані тут відомості про Персона.
                Surname=x.Surname,
                Name=x.Name,
                Telephone = x.Number,
                Gen =x.Gender                

            }).ToList();

            // повертаємо список отриманих Персонів.
            return personmod;
        }

    }
}
