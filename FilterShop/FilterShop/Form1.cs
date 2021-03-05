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
        public List<string> cat_prop { get; set; }
        private List<string> cat = new List<string>();
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

        public bool flag_forma { get; set; } = false;
        /// <summary>
        /// Допоміжні змінні для зміни координат в фільтрі "Форма випуску"
        /// </summary>
        /// 
        public int f { get; set; } = 13;
        public int fy { get; set; } = 30;

        /// <summary>
        /// Кількість елементів в колекції для того,щоб панель і кнопки могла рухатись вниз на потрібну кількість.
        /// </summary>
        public int count_brand { get; set; }
        public int count_taste { get; set; }

        const int s_pos = 65;
        const int t_pos = 12;

        public Form1()
        {
            InitializeComponent();
            _context = new MyContext();
            DbSeeder.SeedDatabase(_context);            
            DataLoad();
        }    
        
        private List<FNameViewModel> GetListFilters()
        {
            

            var queryName = from f in _context.FilterNames.AsQueryable()
                            select f;

            //Зберегла в пропертіз отриманий список назв фільтрів.
            filter = queryName;

           
            var queryGroup = from g in _context.FilterNameGroups.AsQueryable()
                             select g;
            
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

          
            var groupNames = query.AsEnumerable()
                      .GroupBy(f => new { Id = f.FNameId, Name = f.FName })
                      .Select(g => g)
                      .OrderBy(p => p.Key.Name);
 

            
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
           
            GetListFilters();
            //Отримую множину значень імен.
            var resul = from b in GetListFilters()                       
                        select b.Name;

            //Додаю в комбобокс.
            foreach (var item in resul)
            {
                cb_name_parent.Items.Add(item);
            }

            btntaste.Location = new Point(15,btnbrand.Height+dy);
            btnexit_taste.Location = new Point(btntaste.Width + 32, btnexit_brand.Height + dy);
            btn_forma.Location = new Point(15,btntaste.Height+btnbrand.Height+dy+19);
            btnexit_forma.Location = new Point(btn_forma.Width+32,btnexit_brand.Height+btnexit_taste.Height+dy+19);
            lbl_Title_check.Text = "Перелік обраних фільтрів:";
            lbl_name_parent.Text = "Назва фільтра:";
            lbl_name_value.Text = "Елемент:";
        }

        
        private void btnbrand_Click(object sender, EventArgs e)
        {
           //Якщо кнопка розкрита.
            flag = true; 
            
            List<string> brand = new List<string>();           
            var filters = GetListFilters();

            //Отримали значення.
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
            //Кількість елементів у колекції.
            count_brand = brand.Count;
          
            //Створення чекбоксів.
            foreach (var item in brand)
            {
                
                panel_first.Height += dy;
                CheckBox cb = new CheckBox();
                cb.Text = item.ToString();
                cb.Location = new Point(15, y);
                cb.Size = new System.Drawing.Size(150, 22);
                cb.CheckedChanged += CheckChangedHandler;
                cb.UseVisualStyleBackColor = true;
                panel_first.Controls.Add(cb);
                y += dy;
            }           
            y = 10;

            //Координати кнопок в залежності від того розкрита чи закрита кнопка.
            if (flag && !flag_taste)
            {
               
                btntaste.Location = new Point(15, btnbrand.Height * brand.Count + dy);
                btnexit_taste.Location = new Point(btntaste.Width + 32, btnbrand.Height * brand.Count + dy);
               
                panel_second.Location = new Point(15, btnbrand.Height + dy + y);
                panel_second.Controls.Clear();
                panel_second.Height = 5;

                btn_forma.Location = new Point(15,(btnbrand.Height*count_brand)+btntaste.Height+dy+y);
                btnexit_forma.Location = new Point(btn_forma.Width+dy,btnbrand.Height+(btnbrand.Height*count_brand)+btntaste.Height);
                
            }
            if (flag && flag_taste)
            {
                btntaste.Location = new Point(15, btnbrand.Height * count_brand + dy);
                btnexit_taste.Location = new Point(btntaste.Width + 32, btnexit_brand.Height * count_brand + dy);
                panel_second.Location = new Point(15, btnbrand.Height * count_brand + btntaste.Height + dy);

                btn_forma.Location = new Point(btnbrand.Width+btnexit_brand.Width+(y*5),t_pos);
                btnexit_forma.Location = new Point(btnbrand.Width + btnexit_brand.Width + btn_forma.Width + s_pos, t_pos);
                                
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
                btn_forma.Location = new Point(15,btnbrand.Height+btntaste.Height+dy+y);
                btnexit_forma.Location = new Point(btn_forma.Width+dy  ,btnbrand.Height+btntaste.Height+btn_forma.Height);
                              
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
                cb.CheckedChanged += CheckChangedHandler;
                cb.UseVisualStyleBackColor = true;
                panel_second.Controls.Add(cb);
                z += ty;
            }

            if (!flag && flag_taste)
            {
                z = 10;
                btntaste.Location = new Point(15, btnbrand.Height + ty);
                btnexit_taste.Location = new Point(btntaste.Width + 32, btnexit_brand.Height + ty);
                btn_forma.Location = new Point(15, (btntaste.Height * count_taste) + btnbrand.Height + ty);
                btnexit_forma.Location = new Point(btntaste.Width+ty,btnexit_brand.Height+btnexit_taste.Height+(btnexit_taste.Height*count_taste)-z);
                panel_second.Location = new Point(15, btnbrand.Height + btntaste.Height + ty);
                
            }

            if (flag && flag_taste)
            {
                btn_forma.Location = new Point(btnbrand.Width + btnexit_brand.Width + 50, t_pos);
                btnexit_forma.Location = new Point(btnbrand.Width + btnexit_brand.Width + btn_forma.Width +s_pos, t_pos);
                btntaste.Location = new Point(15, btnbrand.Height * count_brand + ty);
                btnexit_taste.Location = new Point(btntaste.Width + 32, btnexit_brand.Height * count_brand + ty);
                panel_second.Location = new Point(15, btnbrand.Height * count_brand + btntaste.Height + ty);
                
            }
            if(flag_forma)
            {
                btn_forma.Location = new Point(btnbrand.Width + btnexit_brand.Width + 50, t_pos);
                btnexit_forma.Location = new Point(btnbrand.Width + btnexit_brand.Width + btn_forma.Width + s_pos, t_pos);
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
                btn_forma.Location = new Point(15, btnbrand.Height + btntaste.Height + ty+z);
                btnexit_forma.Location = new Point(btntaste.Width+ty , btnbrand.Height + btntaste.Height + z+ty);
                               
            }
            else
            {
                btntaste.Location = new Point(15, btnbrand.Height *count_brand+ ty);
                btnexit_taste.Location = new Point(btntaste.Width+32,btnexit_brand.Height*count_brand+ty);                                                 
                
            }
            if(flag_forma)
            {
                panel_third.Controls.Clear();
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
                cb.Size = new System.Drawing.Size(100, 20);               
                cb.CheckedChanged += CheckChangedHandler;
                cb.UseVisualStyleBackColor = true;
                panel_third.Controls.Add(cb);
                f += fy;                        
            }         

            panel_third.Location = new Point(btnbrand.Width+btnexit_brand.Width+60,btn_forma.Height+15);
            if(flag && !flag_taste)
            {
                btn_forma.Location = new Point(btnbrand.Width + btnexit_brand.Width + 50, t_pos);
                btnexit_forma.Location = new Point(btnbrand.Width + btnexit_brand.Width + btn_forma.Width + s_pos, t_pos);
                panel_third.Location = new Point(btnbrand.Width + btnexit_brand.Width + 60, btn_forma.Height + 15);
            }
            if(!flag && !flag_taste)
            {
                panel_third.Location = new Point(btnbrand.Width + btnexit_brand.Width + 60, btn_forma.Height + 15);
            }

            
        }

        private void btnexit_forma_Click(object sender, EventArgs e)
        {
            panel_third.Controls.Clear();
            f = 10;
        }

        /// <summary>
        /// Додавання чекнутих значень з чекбоксів в лістбокс.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {

            lbox_res.Items.Clear();

            foreach (var items in cat)
            {
                lbox_res.Items.Add(items);
            }

        }

        /// <summary>
        /// Обробник чекнутих чекбоксів додавання в ліст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        private void CheckChangedHandler(object sender, EventArgs ea)
        {
            CheckBox cb = sender as CheckBox;
            
            if (cb.Checked)
            {
                cat.Add(cb.Text);                
                //MessageBox.Show(cb.Text + " checked");                
            }          
            
            
        }       

        private void btn_add_value_Click(object sender, EventArgs e)
        {
            _context.FilterValues.Add(
                            new FilterValue
                            {
                                Name = tb_add_value.Text
                                //Name = cb_name_parent.SelectedItem.ToString()
                            });
            _context.SaveChanges();

            var nId = _context.FilterNames
                        .SingleOrDefault(fname => fname.Name == cb_name_parent.SelectedItem.ToString()).Id;
            var vId = _context.FilterValues
                .SingleOrDefault(fvalue => fvalue.Name == tb_add_value.Text).Id;
            if (_context.FilterNameGroups
                       .SingleOrDefault(f => f.FilterValueId == vId &&
                       f.FilterNameId == nId) == null)
            {
                _context.FilterNameGroups.Add(
                            new FilterNameGroup
                            {
                                FilterNameId = nId,
                                FilterValueId = vId
                            });
                _context.SaveChanges();
            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            lbox_res.Items.Clear();
                        
        }
    }
}

