using FormRoles;
using Roles.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoleForm
{
    public partial class Form1 : Form
    {
        MyContext context = new MyContext();
        public Form1()
        {
            InitializeComponent();         
            AddData.Add(context);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ShowAll().ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Search().ShowDialog();
        }
    }
}
