using System;
using System.Collections.Generic;
using System.Text;

namespace FormRoles.Service
{
    public class SearchUser
    {
       /// <summary>
       /// Поля для пошуку
       /// </summary>
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }

        /// <summary>
        /// Кількість одноразового виводу запису на сторінку.
        /// </summary>
        public int CountPage { get; set; } = 3;

        public int Page { get; set; }
    }
}
