using Doctors;
using System;
using System.Windows.Forms;

namespace DoctorsForm
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
            ShowAllcs form2 = new ShowAllcs();
            form2.Show();
           // Hide();           

            //form2.ShowDialog();
            //Application.Exit();
           
           
           


        }
    }
}
