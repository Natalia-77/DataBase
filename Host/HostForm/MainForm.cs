using Host;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace HostForm
{
    public partial class MainForm : Form
    {
        bool isPass = false;

        public MainForm()
        {
            LoginForm log = new LoginForm();
            if(log.ShowDialog()==DialogResult.OK)
            {
                isPass = true;                
            }
           // log.ShowDialog();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!isPass)
            {
                Application.Exit();
            }
            else
            {
                MyContext context = new MyContext();
                foreach (var item in context.Doctors.Include(x => x.Department))
                {
                    object[] obj =
                    {
                    $"{item.LastName}",
                    $"{item.Department.NumberCabinet}",
                    $"{item.Stage}",
                    $"{item.Department.Name}"
                    };

                    dataGridView1.Rows.Add(obj);
                }
                pictureBox1.Image = Image.FromFile("Pictures/1.jpg");



            }
        }       
    }
}
