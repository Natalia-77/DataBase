using Doctores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoctorForm
{
    public partial class FormPagin : Form
    {
        
        static int counts=0;
        public bool action = false;

       
        public FormPagin()
        {            
            InitializeComponent();           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //counts++;
            action =true;
                      
        }
        public void Pagination_Load(object sender, EventArgs e)
        {
            
                int pagecount = 20;
                MyContext context = new MyContext();
                List<Doctor> res = new List<Doctor>();
                //var departm = context.Doctors.Include(x => x.Department);

                do
                {
                    if (counts >= 0)
                    {
                        dataGridView1.Rows.Clear();
                        counts++;
                        int index = (counts - 1) * pagecount;
                        //var departm = context.Doctors.Include(x => x.Department);
                        var departm = context.Doctors.Include("Department").ToList();
                        var result = departm.Skip(index).Take(pagecount);

                        foreach (var item in result)
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

                } while (action);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
