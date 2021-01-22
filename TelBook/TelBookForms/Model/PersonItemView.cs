using System;
using System.Collections.Generic;
using System.Text;

namespace TelBookForms.Model
{

    public class PersonItemModel
    {
        public List<PersonItemView> Persons { get; set; }
        public int CountRows { get; set; }
    }

    public class PersonItemView
    {
        //public int PersonId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Gen { get; set; }
    }
}
