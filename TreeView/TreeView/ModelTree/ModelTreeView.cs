using System;
using System.Collections.Generic;
using System.Text;

namespace TreeViewForm.ModelTree
{
    public class ModelTreeView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
