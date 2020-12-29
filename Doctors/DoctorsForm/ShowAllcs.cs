using Doctors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DoctorsForm
{
    public partial class ShowAllcs : Form
    {
        public ShowAllcs()
        {
            InitializeComponent();
        }

        private void ShowAll_Load(object sender, EventArgs e)
        {
            MyContext context = new MyContext();

            foreach (var item in context.Doctors.Include(x => x.Department))
            {
                object[] row = {
                    $"{item.LastName}",
                    $"{item.FirstName}",
                    $"{item.Stage}",
                    $"{item.Department.NumberCabinet}"

                };

                dataGridView1.Rows.Add(row);
            }
        }
    }
}
