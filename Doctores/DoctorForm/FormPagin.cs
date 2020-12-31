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
        public int counts { get; set; }
        public FormPagin()
        {
            this.counts = 0;
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counts++;
        }
        public void Pagination_Load(object sender, EventArgs e)
        {
            //_ = counts;
            int pagecount = 3;
            MyContext context = new MyContext();
            List<Doctor> res = new List<Doctor>();
            //var departm = context.Doctors.Select(c => c.Id);
            var departm = context.Doctors.Include(x => x.Department);
            foreach (var item in departm)
            {
                //res.Add(item);
               
            }

            //if (counts >= 1 && counts <= 5)
            //{
                //int index = (counts - 1) * pagecount;
                var result = departm.Skip(0).Take(pagecount);

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

                
            //}
           
        }
    }
}
