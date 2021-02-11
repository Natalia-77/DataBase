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
        private readonly MyContext _context = new MyContext();
        public Search()
        {
            InitializeComponent();
        }
        private void Search_Load(object sender, EventArgs e)
        {
             SearchUserGrid();
        }


        private void SearchUserGrid(SearchUser sea = null)
        {   /// Очищаємо грід перед кожним виводом наступної сторінки.
            dataGridView1.Rows.Clear();
            sea ??= new SearchUser();
            sea.Page = page;

            //Отримуємо дані,згенеровані відповідно до запитів у PersonService.
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

            //Обрана в комбобокс кількість об"єктів для відображення.
            //var countSelect = comboBox1.SelectedItem as ComboBoxPerson;

            //Приводимо до інта ім"я,що містило значення  кількості елементів до показу.
            //search.CountPage = int.Parse(countSelect.Name);

            return search;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            page = 1;
            SearchUserGrid(GetData());
        }
    }
}
