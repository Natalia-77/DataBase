using Doctores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            DialogResult = DialogResult.OK;
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
