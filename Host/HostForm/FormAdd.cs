using Host;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HostForm
{
    public partial class FormAdd : Form
    {
        MyContext context = new MyContext();
        public FormAdd()
        {          
            InitializeComponent();
            //checkBox2_CheckedChanged += checkBox2_CheckedChanged;
        }

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    checkBox2.Image = Image.FromFile("{D:\\Pictures/rr.jpg}");
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            context.Doctors
                      .Add(
                      new Doctor
                      {
                          LastName = Convert.ToString(textBox1.Text),
                          FirstName = textBox2.Text,
                          Login = textBox3.Text,
                          Password = Codify.HashPassword(textBox4.Text),                         
                          Image = "rr.jpg",
                          Department = context.Departments
                           .FirstOrDefault(x => x.Name == textBox6.Text),
                          Stage = int.Parse(textBox5.Text)
                      }) ;
           

            context.SaveChanges();
        }

        
    }
}
