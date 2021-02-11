using System;
using System.Collections.Generic;
using System.Text;

namespace FormRoles.Service
{
    /// <summary>
    /// Поля,які будуть відображатись після пошуку.
    /// </summary>
    public class UsersView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
       

    }

    /// <summary>
    /// Список Юзерів,що будуть відображатись.
    /// </summary>
    public class UserListModel
    {
        /// <summary>
        /// Ліст відображуваних значень.
        /// </summary>
        public List<UsersView> Users { get; set; }

        /// <summary>
        /// Загальна кількість знайдених елементів.
        /// </summary>
        public int CountRows { get; set; }

    }

}
