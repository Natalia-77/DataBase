using FormRoles.Service;
using Roles.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormRoles
{
    public partial class Search : Form
    {
        private int page = 1;
        private  MyContext _context = new MyContext();
        public string string_value { get; set; }
        public Search()
        {
            InitializeComponent();
        }
        private void Search_Load(object sender, EventArgs e)
        {
            label7.Text = "Станьте курсором в гріді на строчці(на самому тексті) потрібного користувача";
            label5.Text = "Тут буде вказано дані користувача,на яких буде стояти курсор в гріді";
            label6.Text = "Введіть нове відкориговане прізвище:";
            SearchUserGrid();
            //dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

        }
        //void dataGridView1_SelectionChanged(object sender, EventArgs e)
        //{
        //    dataGridView1.ReadOnly = true;
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView1.CurrentCell.Value.ToString();
            label5.Text = str;
            string_value=str;            
        }

        private void EditUserData()
        {            
            User us = _context.Users.SingleOrDefault(x => x.Surname == string_value);
            if (us != null)
            {
                us.Surname = textBox4.Text;
                _context.SaveChanges();
            }
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
                    item.Id,                   
                    item.Name,
                    item.Surname,
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

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    dataGridView1.ReadOnly = false;
        //    dataGridView1.BeginEdit(true);
        //}

        private void button4_Click_1(object sender, EventArgs e)
        {
            EditUserData();
        }
    }
}
