using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HostForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string pass = textBox2.Text;

            if (login == "nata" && pass == "123")
            {
               // MainForm form = new MainForm();
                //form.ShowDialog();
                MessageBox.Show($"Wellcome, {login}");
            }
            else
            {
                MessageBox.Show("Noname");
            }
        }
    }
}
