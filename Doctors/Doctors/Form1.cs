using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctors
{
    public partial class Form1 : Form
    {
        private readonly MyContext context;

        public Form1()
        {
            context = new MyContext();
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            AddData.AddDepartment(context);
        }
    }
}
