using FormRoles.Service;
using Roles.DAL;
using Roles.DAL.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormRoles
{
    
    public partial class AddNewUser : Form
    {
        MyContext context = new MyContext();
        public AddNewUser()
        {
            InitializeComponent();
        }
        private void AddNewUser_Load(object sender, EventArgs e)
        {
            foreach (var role in context.Roles)
            {
                RoleComboBoxItem item = new RoleComboBoxItem
                {
                    Id = role.Id,
                    Name = role.Name
                };
                comboBox1.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            context.Users
               .Add(
               new User
               {                  
                   Name = textBox1.Text,
                   Surname = textBox2.Text,
                   Login = textBox3.Text,
                   Password = PassHash.HashPassword(textBox4.Text)
               });
            context.SaveChanges();
            var infoid = context.Users.Max(x => x.Id);
            var item = comboBox1.SelectedItem;
            if (item != null)
            {
                var rol = comboBox1.SelectedItem as RoleComboBoxItem;

                context.UserRoles
                   .Add(new UserRoles
                   {
                       UserId = infoid,
                       RoleId =rol.Id
                   }); 
                context.SaveChanges();
            }
           
        }
    }
}
