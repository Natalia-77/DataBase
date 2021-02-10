using Microsoft.EntityFrameworkCore;
using Roles.DAL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FormRoles
{
    public partial class ShowAll : Form
    {
        public ShowAll()
        {
            InitializeComponent();
        }

        public void Data_Load(object sender, EventArgs e)
        {
            MyContext context = new MyContext();            

            var info = context.UserRoles.Include(u => u.User).Include(rol=>rol.Role).AsQueryable();

            var list = info.Select(r => new 
            {
                Id = r.User.Id,
                Name = r.User.Name,
                Surname = r.User.Surname,                
                //Roles = r.RoleId,
                Roles=r.Role.Name
              

            }).AsQueryable();       
            
            foreach (var item in list)
            {
                object[] row =
                       {$"{item.Id}",
                        $"{item.Name}",
                        $"{item.Surname}",                         
                        $"{item.Roles}"
                    };

                dataGridView1.Rows.Add(row);

            }
        }
    }
}
