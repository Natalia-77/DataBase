using FormRoles.Service;
using Roles.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormRoles
{
    public partial class Search : Form
    {
        private int page = 1;
        private  MyContext _context = new MyContext();
        public Search()
        {
            InitializeComponent();
        }
        private void Search_Load(object sender, EventArgs e)
        {
             SearchUserGrid();
        }


        private void SearchUserGrid(SearchUser sea = null)
        {
            // Очищаємо грід перед кожним виводом наступної сторінки.
            dataGridView1.Rows.Clear();

            // Якщо SearchUser sea==null,то створю новий об"єкт класу.Якщо не null,то використ вже наявний екземпляр.
            sea ??= new SearchUser();
            sea.Page = page;

            //Отримуємо дані,згенеровані відповідно до запитів у UserSearchService.
            var res = UserSearchService.SearchUser(_context, sea);
            foreach (var item in res.Users)
            {
                object[] row =
                {                  
                   // item.PersonId,
                    item.Surname,
                    item.Name,
                    item.Position
                };
                dataGridView1.Rows.Add(row);
            }
        }

        private SearchUser GetData()
        {
            SearchUser search = new SearchUser();

            //Введені користувачем дані для пошуку передаємо в SearchUser.
            search.Name = textBox1.Text;
            search.Surname = textBox2.Text;
            search.Position = textBox3.Text;           

            return search;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            page = 1;
            SearchUserGrid(GetData());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            page += 1;
            SearchUserGrid(GetData());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page -= 1;
                SearchUserGrid(GetData());
            }
        }
    }
}
