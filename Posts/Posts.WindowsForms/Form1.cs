using Microsoft.EntityFrameworkCore;
using Posts.DAL;
using System;
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
               
                object[] row = {
                    $"{item.Name}",
                    $"{item.Description}"
                };
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
