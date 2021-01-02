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
    public partial class FormSearch : Form
    {
        public string Depname { get; set; }
        static int count = 0;
        public bool act = false;
       
        public FormSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            act = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           Depname=this.textBox1.Text;
        }
        public void Search_Load(object sender, EventArgs e)
        {          
                int pagecount = 5;
                MyContext context = new MyContext();
               
                do
                {
                    if (count >= 0)
                    {
                       // dataGridView1.Rows.Clear();
                        count++;
                        int index = (count - 1) * pagecount;
                        //var departm = context.Doctors.Include(x => x.Department);
                        //var departm = context.Doctors.Where(c => c.Department.Name == textBox1.Text).Select(x => x.Department).FirstOrDefault();//.ToList();
                        var departm = context.Doctors.Include("Department").Where(c => c.Department.Name == Depname).ToList();
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

                } while (act);
            
        }

        
    }
}
