using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelBook;

namespace TelBookForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Заповнення бази даних.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MyContext context = new MyContext();
            AddDataPerson.AddPerson(context);
        }
        /// <summary>
        /// Перехід в форму для здійснення дій(пошук,відображення в певній послідовності і кількості).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            new ShowAll().ShowDialog();
        }
    }
}
