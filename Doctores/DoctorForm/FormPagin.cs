using Doctores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DoctorForm
{
    public partial class FormPagin : Form
    {
        MyContext context = new MyContext();
        static int pagecount = 20;
        static int counts=0;
        bool action = false;
        bool act2 = false;

       
        public FormPagin()
        {            
            InitializeComponent();           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {           
            action =true;                      
        }
        private void button3_Click(object sender, EventArgs e)
        {          
            act2 = true;
        }

        public void Up_Load(object sender, EventArgs e)
        {            
                
             do
             {                
           
                    if (counts >= 0 )
                    {
                        dataGridView1.Rows.Clear();     
                        counts++;
                        int index = (counts - 1) * pagecount;                       
                        var departm = context.Doctors.Include("Department").ToList();
                        var result = departm.Skip(index).Take(pagecount);
                        double total = departm.Count() / pagecount;                    

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
                        if (counts > total)
                        {
                            counts = 0;
                        }
                    }               

               } while (action);

            
        }

        public void Down_Load(object sender, EventArgs e)
        {
           
            do
            {

                if (counts >= 0)
                {
                    dataGridView1.Rows.Clear();
                    counts--;
                    int index = (counts - 1) * pagecount;                    
                    var departm = context.Doctors.Include("Department").ToList();
                    var result = departm.Skip(index).Take(pagecount);
                    double total = departm.Count() / pagecount;


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
                    if (counts > total)
                    {
                        counts = 0;
                    }
                }


            } while (act2);


        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
