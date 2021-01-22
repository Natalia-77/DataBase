using System;
using System.Collections.Generic;
using System.Text;

namespace TelBookForms
{
    public class Search
    {
       
        /// <summary>
        /// Поля для пошуку.
        /// </summary>       
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Кількість відображення позицій при натисканні кнопки.
        /// </summary>
        public int CountPage { get; set; } = 7;
       

    }
}
