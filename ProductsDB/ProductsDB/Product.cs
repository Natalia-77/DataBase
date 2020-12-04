using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDB
{
     public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return $"{Id}. {ProductName} -> {string.Format("{0:#.00}",Convert.ToDecimal(Price)/100)}  ";
        }
    }

    public class Search
    {
        //public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
