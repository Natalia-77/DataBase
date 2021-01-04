using Doctores;
using System;
using System.Windows.Forms;

namespace DoctorForm
{
    public partial class Form1 : Form
    {
            
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyContext context = new MyContext();
            AddData.AddDepartment(context);
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            new ShowAll().ShowDialog();           
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            new FormPagin().ShowDialog();            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FormSearch().ShowDialog();
        }
    }
}
