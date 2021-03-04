using FilterShop.Entities;
using FilterShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FilterShop
{
    public partial class Form1 : Form
    {
        private readonly MyContext _context;
        public IQueryable<FilterName> filter { get; set; }
        /// <summary>
        /// Допоміжні змінні для зміни координат в фільтрі "Бренд"
        /// </summary>
        public int y { get; set; } = 5;
        public int dy { get; set; } = 30;

        /// <summary>
        /// Допоміжні змінні для зміни координат в фільтрі "Смаки"
        /// </summary>
        public int z { get; set; } = 10;
        public int ty { get; set; } = 30;
        /// <summary>
        /// Фолс по замовчуванню,то кнопка не розкрита на початковій формі фільтру "Бренд".
        /// </summary>
        public bool flag { get; set; } = false;

        /// <summary>
        /// Фолс по замовчуванню,то кнопка не розкрита на початковій формі фільтру "Смаки".
        /// </summary>
        public bool flag_taste { get; set; } = false;

        /// <summary>
        /// Фолс по замовчуванню,то кнопка не розкрита на початковій формі фільтру "Форма випуску".
        /// </summary>
        public bool flag_forma { get; set; } = false;

        /// <summary>
        /// Допоміжні змінні для зміни координат в фільтрі "Форма випуску"
        /// </summary>
        /// 
        public int f { get; set; } = 10;
        public int fy { get; set; } = 30;

        public int count_brand { get; set; }
        public int count_taste { get; set; }

        public Form1()
        {
            InitializeComponent();
            _context = new MyContext();
            DbSeeder.SeedDatabase(_context);            
            DataLoad();
        }    
        
        private List<FNameViewModel> GetListFilters()
        {
            lblTitle_first.Text = "Оберіть перший фільтр";
            lblTitle_second.Text = "Оберіть другий фільтр";

            var queryName = from f in _context.FilterNames.AsQueryable()
                            select f;
            filter = queryName;
            var countSelect = comboBox1.SelectedItem as FilterName;


            var queryGroup = from g in _context.FilterNameGroups.AsQueryable()
                             select g;
            //Отримуємо загальну множину значень
            var query = from u in queryName
                        join g in queryGroup on u.Id equals g.FilterNameId into ua
                        from aEmp in ua.DefaultIfEmpty()
                        select new
                        {
                            FNameId = u.Id,
                            FName = u.Name,
                            FValueId = aEmp != null ? aEmp.FilterValueId : 0,
                            FValue = aEmp != null ? aEmp.FilterValueOf.Name : null,
                        };


            //Групуємо по іменам і сортуємо по спаданню імен

            var groupNames = query.AsEnumerable()
                      .GroupBy(f => new { Id = f.FNameId, Name = f.FName })
                      .Select(g => g)
                      .OrderBy(p => p.Key.Name);
 

            //По групах отримуємо
            var result = from fName in groupNames
                         select
                         new FNameViewModel
                         {
                             Id = fName.Key.Id,
                             Name = fName.Key.Name,
                             Children = fName.Select(x =>
                                   new FValueViewModel
                                   {
                                       Id = x.FValueId,
                                       Value = x.FValue
                                   }).OrderBy(l => l.Value).ToList()
                                   
                         };            

            return result.ToList();
        }

        private void DataLoad()
        {
           // clb1.Items.Clear();

            GetListFilters();
            btntaste.Location = new Point(15,btnbrand.Height+dy);
            btnexit_taste.Location = new Point(btntaste.Width + 32, btnexit_brand.Height + dy);
            btn_forma.Location = new Point(15,btntaste.Height+btnbrand.Height+dy+19);
            btnexit_forma.Location = new Point(btn_forma.Width+32,btnexit_brand.Height+btnexit_taste.Height+dy+19);
            //foreach (var item in filter)
            //{
            //    comboBox1.Items.Add(item.Name);
                
            //}
            
            //var resul = from b in GetListFilters()
            //            where b.Name !=comboBox1.SelectedItem.ToString()
            //            select b.Name;
          
           
            //foreach (var item in resul)
            //{
            //                comboBox2.Items.Add(item);                


            //}
        }

        /// <summary>
        /// Get checked elements in other list        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> brand = new List<string>();

            for (int i = 0; i <clb1.CheckedItems.Count ; i++)
            {                
                brand.Add(clb1.CheckedItems[i].ToString());                
            }

            listBox1.Items.Clear();

            foreach (var item in brand)
            {
                listBox1.Items.Add(item);
            }
        }


        /// <summary>
        /// Check caterory name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var filters = GetListFilters();
            var res = from c in filters
                      where c.Name == comboBox1.SelectedItem.ToString()
                      select c.Children;
            clb1.Items.Clear();
            foreach (var item in res)
            {
                foreach (var t in item)
                {
                    clb1.Items.Add(t.Value, false);
                }
            }

            var resul = from b in GetListFilters()
                        where b.Name != comboBox1.SelectedItem.ToString()
                        select b.Name;


            foreach (var item in resul)
            {
                comboBox2.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var filters = GetListFilters();
            var res = from c in filters
                      where c.Name == comboBox2.SelectedItem.ToString()
                      select c.Children;
            clb2.Items.Clear();
            foreach (var item in res)
            {
                foreach (var t in item)
                {
                    clb2.Items.Add(t.Value, false);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> category2 = new List<string>();

            for (int i = 0; i < clb2.CheckedItems.Count; i++)
            {
                category2.Add(clb2.CheckedItems[i].ToString());
            }

            listBox2.Items.Clear();

            foreach (var item in category2)
            {
                listBox2.Items.Add(item);
            }
        }

        private void btnbrand_Click(object sender, EventArgs e)
        {            
            flag = true;           
            List<string> brand = new List<string>();
            //panel_first.Height = 5;
           // panel_first.Controls.Clear();
           // y = 5;
            //panel_second.Controls.Clear();
            var filters = GetListFilters();
            var res = from c in filters
                      where c.Name == btnbrand.Text
                      select c.Children;
           
            foreach (var item in res)
            {
                foreach (var t in item)
                {
                    brand.Add(t.Value);
                }            
                      
            }
            count_brand = brand.Count;
          
            foreach (var item in brand)
            {
                
                panel_first.Height += dy;
                CheckBox cb = new CheckBox();
                cb.Text = item.ToString();
                cb.Location = new Point(15, y);
                cb.Size = new System.Drawing.Size(150, 22);
                cb.UseVisualStyleBackColor = true;
                panel_first.Controls.Add(cb);
                y += dy;
            }
            if (flag&&!flag_taste)
            {
                btntaste.Location = new Point(15, btnbrand.Height * brand.Count + dy);
                btnexit_taste.Location = new Point(btntaste.Width + 32, btnbrand.Height * brand.Count + dy);
                panel_second.Location = new Point(15,btnbrand.Height+dy+y);
                panel_second.Controls.Clear();
                panel_second.Height = 5;
            }
            if(flag && flag_taste)
            {
                btntaste.Location = new Point(15, btnbrand.Height * count_brand + dy);
                btnexit_taste.Location = new Point(btntaste.Width + 32, btnexit_brand.Height * count_brand + dy);
                panel_second.Location = new Point(15, btnbrand.Height * count_brand + btntaste.Height + dy);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            flag = false;
            panel_first.Controls.Clear();
            panel_first.Height = 5;
            y = 10;
            btntaste.Location = new Point(15, btnbrand.Height + dy);               
            btnexit_taste.Location = new Point(btntaste.Width + 32, btnbrand.Height + dy);
            if (!flag_taste)
            {                
                panel_second.Controls.Clear();
                panel_second.Height = 5;
            }
            panel_second.Location = new Point(15, btnbrand.Height + btntaste.Height + dy);
        }

        private void btntaste_Click(object sender, EventArgs e)
        {           
            flag_taste = true;
            List<string> taste = new List<string>();           
            var filters = GetListFilters();
            var res = from c in filters
                      where c.Name == btntaste.Text
                      select c.Children;

            foreach (var item in res)
            {
                foreach (var t in item)
                {
                    taste.Add(t.Value);
                }
            }
            count_taste = taste.Count;
            foreach (var item in taste)
            {
                panel_second.Height += ty;
                CheckBox cb = new CheckBox();
                cb.Text = item.ToString();
                cb.Location = new Point(15, z);
                cb.Size = new System.Drawing.Size(150, 22);
                cb.UseVisualStyleBackColor = true;
                panel_second.Controls.Add(cb);
                z += ty;
            }
            
            if (!flag&&flag_taste)
            {               
                btntaste.Location = new Point(15, btnbrand.Height + dy);
                btnexit_taste.Location = new Point(btntaste.Width + 32, btnexit_brand.Height + dy);
                btn_forma.Location = new Point(15, btnbrand.Height + btntaste.Height * count_taste + dy);
;               panel_second.Location = new Point(15, btnbrand.Height + btntaste.Height + dy);
                
            }
            
            if(flag&&flag_taste)
            {
                btntaste.Location = new Point(15, btnbrand.Height*count_brand + dy);
                btnexit_taste.Location = new Point(btntaste.Width + 32, btnexit_brand.Height*count_brand + dy);
                btn_forma.Location = new Point(15, btnbrand.Height * count_brand + btntaste.Height*count_taste + dy);
                panel_second.Location = new Point(15, btnbrand.Height*count_brand + btntaste.Height + dy);               
            }
            if(flag&&!flag_taste)
            {

            }
        }

        private void btnexit_taste_Click(object sender, EventArgs e)
        {
            flag_taste = false;
            panel_second.Controls.Clear();
            panel_second.Height = 5;
            z = 10;

            if (!flag)
            {
                panel_first.Controls.Clear();
                panel_first.Height = 5;
            }
            else
            {
                btntaste.Location = new Point(15, btnbrand.Height *count_brand+ dy);
                btnexit_taste.Location = new Point(btntaste.Width+32,btnexit_brand.Height*count_brand+dy);

            }

        }

        private void btn_forma_Click(object sender, EventArgs e)
        {
            flag_forma = true;
            List<string> forma = new List<string>();
            var filters = GetListFilters();
            var res = from c in filters
                      where c.Name == btn_forma.Text
                      select c.Children;

            foreach (var item in res)
            {
                foreach (var t in item)
                {
                    forma.Add(t.Value);
                }
            }

            foreach (var item in forma)
            {
                panel_third.Height += fy;
                CheckBox cb = new CheckBox();
                cb.Text = item.ToString();
                cb.Location = new Point(15, f);
                cb.Size = new System.Drawing.Size(150, 20);
                cb.UseVisualStyleBackColor = true;
                panel_third.Controls.Add(cb);
                f += fy;
            }
           // btn_forma.Location = new Point(15, btnbrand.Height * count_brand + btntaste.Height + dy + 5);
            if ( flag&&!flag_taste)
            {
               
            }

            //if (!flag && flag_taste)
            //{
            //    btntaste.Location = new Point(15, btnbrand.Height + dy);
            //    btnexit_taste.Location = new Point(btntaste.Width + 32, btnexit_brand.Height + dy);
            //    panel_second.Location = new Point(15, btnbrand.Height + btntaste.Height + dy);

            //}
           // if (flag&&flag_taste)
            //{
               // btn_forma.Location = new Point(15, ((btnbrand.Height * count_brand) + (btntaste.Height * count_taste))+dy);
                //btnexit_forma.Location = new Point(btntaste.Width + 32, btnexit_brand.Height * count_brand + dy);
                //panel_second.Location = new Point(15, btnbrand.Height * count_brand + btntaste.Height + dy);
            //}
        }

        private void btnexit_forms_Click(object sender, EventArgs e)
        {

        }
    }
}
