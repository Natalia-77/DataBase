using System;
using System.Collections.Generic;
using System.Text;

namespace TelBookForms.Model
{

    public class PersonItemModel
    {/// <summary>
    /// List відображуваних значень Person.
    /// </summary>
        public List<PersonItemView> Persons { get; set; }
        /// <summary>
        /// Загальна кількість відображуваних даних(всього у базі).
        /// </summary>
        public int CountRows { get; set; }
    }
    /// <summary>
    /// Значення про Персона,що тбудуть відображатись.
    /// </summary>
    public class PersonItemView
    {
        //public int PersonId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Gen { get; set; }
    }
}
