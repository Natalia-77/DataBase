using System;
using System.Collections.Generic;
using System.Text;

namespace FormRoles.Service
{
    public class RoleComboBoxItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
