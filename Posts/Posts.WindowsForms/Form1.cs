using Microsoft.EntityFrameworkCore;
using Posts.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Posts.WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyContext context = new MyContext();
            foreach (var item in context.Categories.Include(x => x.Posts))
            {
                string str=$"{item.Name}--> {item.Description}";
                object[] row = { str };
                dataGridView1.Rows.Add(str);
            }
        }
    }
}
