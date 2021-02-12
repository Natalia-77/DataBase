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
        private MyContext _context = new MyContext();
        public ShowAll()
        {
            InitializeComponent();
        }

        public void Data_Load(object sender, EventArgs e)
        {
            MyContext context = new MyContext();

            label2.Text = "Введіть прізвище користувача,якого потрібно видалити:";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            User d = _context.Users.SingleOrDefault(x => x.Surname == surname);
            if (d != null)
            {
                _context.Users.Remove(d);
                _context.SaveChanges();

            }
        }
    }
}
