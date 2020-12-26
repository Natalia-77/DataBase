using Host;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HostForm
{
    public partial class FormAll : Form
    {              

        public FormAll()
        {
            InitializeComponent();
        }

        private void FormAll_Load(object sender, EventArgs e)
        {
            MyContext context = new MyContext();
            foreach (var item in context.Doctors.Include(x => x.Department))
            {
                object[] row = {
                    $"{item.LastName}",
                    $"{item.Department.NumberCabinet}",
                    $"{item.Stage}",
                    $"{item.Department.Name}"
                };

                dataGridView1.Rows.Add(row);
            }



            //    pictureBox1.Image = Image.FromFile($"Pictures/{LogInstance.Image}");
            //dataGridView1.Rows.Add($"{LogInstance.LastName}",
            //    $"{LogDep.NumberCabinet}",
            //    $"{LogInstance.Stage}",
            //    $"{LogDep.Name}");

        }
        //private void FormProfile_Load(object sender, EventArgs e)
        //{

        //}

    }
}
