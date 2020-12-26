using Host;
using System;
using System.Windows.Forms;

namespace HostForm
{
    public partial class MainForm : Form
    {
        
        public Doctor LogInstancem { get; set; }
        public Department LogDepm { get; set; }

        

        public MainForm()
        {
            LoginForm log = new LoginForm();
            if(log.ShowDialog()==DialogResult.OK)
            {
                LogInstancem = log.EnteredInstance;
                LogDepm = log.EnterDep;
                             
            }
          
            InitializeComponent();
        }

        private void butSeeall_Click(object sender, EventArgs e)
        {
            FormAll all = new FormAll();            
            all.ShowDialog();    
        }

        private void butProfile_Click(object sender, EventArgs e)
        {
            FormProfile prof = new FormProfile();
            prof.ShowDialog();          
                                    
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            FormAdd add = new FormAdd();
            add.ShowDialog();
        }
    }
}
