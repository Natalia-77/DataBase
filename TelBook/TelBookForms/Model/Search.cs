using System;
using System.Collections.Generic;
using System.Text;

namespace TelBookForms
{
    public class Search
    {
       
        /// <summary>
        /// Field for search.
        /// </summary>       
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public int Page { get; set; }
        public int CountPage { get; set; } = 7;
       

    }
}
