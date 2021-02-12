using Roles.DAL;
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
    public partial class DeleteForm : Form
    {
        private MyContext _context = new MyContext();
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            label1.Text = "Введіть прізвище користувача,якого потрібно видалити";
            
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            User d = _context.Users.SingleOrDefault(x => x.Surname==surname);
            if(d!=null)
            {
                _context.Users.Remove(d);
                _context.SaveChanges();

            }
            
            
        }
    }
}
