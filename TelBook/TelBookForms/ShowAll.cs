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
        private int page = 1;
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
            sea.Page = page;
            var res = PersonService.Search(_context, sea);
            foreach (var item in res.Persons)
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
            int start = (page - 1) * 7 + 1;
            //int finish =;
            label6.Text = $"Display result from {start} to {start+6}";
            label4.Text ="Total:"+ res.CountRows.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            page = 1;          
            SearchPerson(GetData());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (page >1)
            {
                page -= 1;
                SearchPerson(GetData());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            page += 1;
            SearchPerson(GetData());
        }

        private Search GetData()
        {
            Search search = new Search();
            search.Name = textBox2.Text;
            search.Surname = textBox1.Text;
            search.Telephone = textBox3.Text;
            return search;
        }
    }
}
