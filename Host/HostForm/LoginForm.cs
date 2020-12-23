using Host;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HostForm
{
    public partial class LoginForm : Form
    {
        private readonly MyContext context;
        public LoginForm()
        {
            context = new MyContext();
            InitializeComponent();
            DbSeeder.SeedAll(context);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string pass = textBox2.Text;

            var doctor = context.Doctors.FirstOrDefault(x => x.Login == login);
            if (doctor != null)
            {
                var passwordHash = doctor.Password;
                if (Codify.Verify(pass, passwordHash))
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("НО...");
            }
            else
                MessageBox.Show("Но-но...");

            //if (login == "nata" && pass == "123")
            //{
                //MainForm form = new MainForm();
                //form.ShowDialog();

                // MessageBox.Show($"Wellcome, {login}");
               // DialogResult = DialogResult.OK;
            //}
            //else
            //{
            //    MessageBox.Show("Noname");
            //}
        }
    }
}
