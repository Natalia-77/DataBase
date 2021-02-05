using Quiz.DAL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuizForm
{
    public partial class LoginForm : Form
    {
        private readonly MyContext context;
        public User UserInstance { get; set; }
       
        public LoginForm()
        {
            context = new MyContext();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string login = textBox1.Text;
            string pass = textBox2.Text;

            var user = context.Users.FirstOrDefault(x => x.Login == login);
            if(user!=null)
            {
                UserInstance = user;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
