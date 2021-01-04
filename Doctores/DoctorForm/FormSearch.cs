using Doctores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DoctorForm
{
    public partial class FormSearch : Form
    {
        MyContext context = new MyContext();
        public string depname { get; set; }
        static int count = 0;
        bool act = false;
       
        public FormSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            act = true;
        }
        
        public void Search_Load(object sender, EventArgs e)
        {          
           
                depname = this.textBox1.Text;            
                int pagecount = 5;               
               
                do
                {
                    if (count >= 0 )
                    {
                    dataGridView1.Rows.Clear();
                    count++;
                    int index = (count-1 ) * pagecount;
                    List<Doctor> departm = context.Doctors.Include("Department").Where(c => c.Department.Name == depname).ToList();
                    IEnumerable<Doctor> result = departm.Skip(index).Take(pagecount);
                    int sizelist = departm.Count();
                    double total = sizelist / pagecount;

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
                    if (count > total)
                    {
                        count = 0;
                    }
                }

                } while (act);           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
