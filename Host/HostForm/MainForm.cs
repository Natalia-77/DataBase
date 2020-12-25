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
        
        public Doctor LogInstance { get; set; }
        public Department LogDep { get; set; }

        public MainForm()
        {
            LoginForm log = new LoginForm();
            if(log.ShowDialog()==DialogResult.OK)
            {
                LogInstance = log.EnteredInstance;
                LogDep = log.EnterDep;
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

                pictureBox1.Image = Image.FromFile($"Pictures/{LogInstance.Image}");
                dataGridView1.Rows.Add($"{LogInstance.LastName}",
                    $"{LogDep.NumberCabinet}",
                    $"{LogInstance.Stage}",
                    $"{LogDep.Name}");

            }
        }



       

        
    }
}
