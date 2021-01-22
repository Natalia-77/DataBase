using System;
using System.Collections.Generic;
using System.Text;

namespace TelBookForms.Model
{       /// <summary>
       /// Клас призначений для додавання даних,необхідних для Комбобокса ,а саме кількості відображуваних елементів.
       /// </summary>
    public class ComboBoxPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
