using Host;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HostForm
{
    public partial class FormProfile : Form
    {      

        public Doctor LogInstancep { get; set; }     
        public Department LogDepp { get; set; }
       

        public FormProfile()
        {
            MainForm m = new MainForm();
            LogInstancep = m.LogInstancem;
            LogDepp = m.LogDepm;
            InitializeComponent();      
           
        }

        private void Profile_Load(object sender, EventArgs e)
        {
           
            pictureBox1.Image = Image.FromFile($"Pictures/{LogInstancep.Image}");
            textBox1.Text = LogInstancep.FirstName;
            textBox2.Text = LogInstancep.Stage.ToString();
            textBox3.Text = LogDepp.Name;
        }


    }
}

