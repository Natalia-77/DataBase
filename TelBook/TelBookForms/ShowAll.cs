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
using TelBookForms.Model;
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
        /// <summary>
        /// Обробник завантаження даних на форму.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowLoad(object sender, EventArgs e)
        {
            SearchPerson();
            
            ///Додавання в комбобокс параметрів кількісного виводу позицій на формі.
            comboBox1.Items.AddRange(
                   new List<ComboBoxPerson> {                       
                            new ComboBoxPerson {Id=1,Name="5"},
                            new ComboBoxPerson {Id=2,Name="10"},
                            new ComboBoxPerson {Id=2,Name="15"},
                      }.ToArray()
                   );

            comboBox1.SelectedIndex = 0;
        }

        private void SearchPerson(Search sea=null)
        {   /// Очищаємо грід перед кожним виводом наступної сторінки.
            dataGridView1.Rows.Clear();
            sea ??= new Search();
            sea.Page = page;

            //Отримуємо дані,згенеровані відповідно до запитів у PersonService.
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
            int start = (page - 1) * sea.CountPage + 1;
            
            ///Відображення проміжку,в якому відбувається виведення даних.
            label6.Text = $"Display result from {start} to {start+(sea.CountPage -1)}";

            ///Відображення загальної кількості позицій і списку.
            label4.Text ="Total:"+ res.CountRows.ToString();

            //Визначаємо кількість кнопок-(Ділимо загальну отриману кількість позицій на номер сторінки).
            int totalPage = (int)Math.Ceiling((double)res.CountRows / sea.CountPage);
                        
            //Позиція,з якої почнеться відображення створених кнопок.
            int pos = 15;
            int dx = 50;

            groupBox1.Controls.Clear();
            for (int i = 1; i <= totalPage; i++)
            {
                Button btn = new Button();
                btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                btn.Location = new System.Drawing.Point(pos, 15);
                btn.Name = $"btnPage{i}";
                btn.Size = new System.Drawing.Size(50, 45);
                btn.Text = $"{i}";
                btn.UseVisualStyleBackColor = true;

               // btn.Click += new System.EventHandler(this.btnPage_Click);
                groupBox1.Controls.Add(btn);
                pos += dx;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //При натисканні кнопки Пошук-номер сторінки встановлюємо перший.
            page = 1;          
            SearchPerson(GetData());
        }
        /// <summary>
        /// При натисканні кнопки Назад-зменшення кількісного вираження номера сторінки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (page >1)
            {
                page -= 1;
                SearchPerson(GetData());
            }
        }
        /// <summary>
        /// При натисканні кнопки Вперед-збільшення кількісного вираження номера сторінки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            page += 1;
            SearchPerson(GetData());
        }
        /// <summary>
        /// Метод ,який повертає введені користувачем дані,які є вихідними для здійснення пошуку.
        /// </summary>
        /// <returns></returns>
        private Search GetData()
        {
            Search search = new Search();
            //Введені користувачем дані для пошуку передаємо в Search.
            search.Name = textBox2.Text;
            search.Surname = textBox1.Text;
            search.Telephone = textBox3.Text;

            //Обрана в комбобокс кількість об"єктів для відображення.
            var countSelect = comboBox1.SelectedItem as ComboBoxPerson;

            //Приводимо до інта ім"я,що містило значення  кількості елементів до показу.
            search.CountPage = int.Parse(countSelect.Name);

            return search;
        }
    }
}
