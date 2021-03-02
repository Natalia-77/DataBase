using System;
using System.Collections.Generic;
using System.Text;

namespace FilterShop.Models
{
    public class FValueViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsChecked { get; set; } = false;
    }
    public class FNameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCollapsed { get; set; } = true;
        public List<FValueViewModel> Children { get; set; }
    }

    
}
