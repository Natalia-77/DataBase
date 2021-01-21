using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TelBook;
using TelBookForms.PersonRead;

namespace TelBookForms
{
    public partial class ShowAll : Form
    {
        private readonly MyContext _context = new MyContext();
        public ShowAll()
        {
            InitializeComponent();
        }

        private void ShowLoad(object sender, EventArgs e)
        {
            SearchPerson();
        }

        private void SearchPerson(Search sea=null)
        {
            dataGridView1.Rows.Clear();
            sea ??= new Search();
            var list = PersonService.Search(_context, sea);
            foreach (var item in list)
            {
                object[] row =
                {                  
                   // item.PersonId,
                    item.Surname,
                    item.Name,
                    item.Telephone,
                    item.Gen
                };
                dataGridView1.Rows.Add(row);
            }
            label4.Text ="Total:"+ list.Count().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.Name = textBox2.Text;
            SearchPerson(search);
        }
    }
}
