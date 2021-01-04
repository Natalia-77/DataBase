using Doctores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DoctorForm
{
    public partial class ShowAll : Form
    {        
       
        public ShowAll()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {           
              Close();
        }

        public void ShowAll_Load(object sender, EventArgs e)
        {
                MyContext context = new MyContext();
                foreach (var item in context.Doctors.Include(x => x.Department))
                {
                    object[] row = {
                        $"{item.LastName}",
                        $"{item.FirstName}",
                        $"{item.Stage}",
                        $"{item.Department.NumberCabinet}",
                        $"{item.Department.Name}"

                    };

                    dataGridView1.Rows.Add(row);


                }
            
            
        }

        
    }
}
