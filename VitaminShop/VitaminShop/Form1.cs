using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VitaminShop.Entetities;
using VitaminShop.Models;

namespace VitaminShop
{
    public partial class Form1 : Form
    {
       
        private readonly MyContext _context;

        /// <summary>
        /// Кількість елементів у Лісті значень імен(кількість імен фільтрів)
        /// </summary>
        public int count { get; set; }

        public int count_child { get; set; }

        int X { get; set; } = 10;

        int Y { get; set; } = 10;

        int interval { get; set; } = 8;

        int dy1 { get; set; }

        const int chb_height = 15;

        /// <summary>
        /// Лічильник кількості кліків на кнопку.
        /// </summary>
        int kol  = 0;

        /// <summary>
        /// Список чекнутих елементів.
        /// </summary>
        private List<int> category = new List<int>();

        Panel pan;

        public int hy { get; set; } 

        public int btnHeight { get; set; } = 48;
        public int btnWidth { get; set; } = 125;

        public string name { get; set; }

        public Form1()
        {
            InitializeComponent();
            _context = new MyContext();   
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoScroll = true;
            SuspendLayout();
            DbSeeder.SeedDatabase(_context);
            Load_Form();           
        }

        private List<FilterNameModel> GetListFilters()
        {


            var queryName = from f in _context.FilterNames.AsQueryable()
                            select f;

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
                         new FilterNameModel
                         {
                             Id = fName.Key.Id,
                             Name = fName.Key.Name,
                             Children = fName.Select(x =>
                                   new FilterValueModel
                                   {
                                       Id = x.FValueId,
                                       Name = x.FValue
                                   }).OrderBy(l => l.Name).ToList()

                         };

            return result.ToList();


        }

        public void Load_Form()
        {
            var collection=GetListFilters();
            List<string> names = new List<string>();
           
            //Отримую множину значень імен.
            var result = from b in collection select b.Name;
            
            foreach (var item in result)
            {
                names.Add(item);                
            }
            count = names.Count;
            // MessageBox.Show($"{count}");                     

           
            for (int i = 0; i < count; i++)
            {
                //hy += hy;
                Button[] btnNameFilter = new Button[count];
                btnNameFilter[i] = new Button();
                btnNameFilter[i].Location = new Point(X, Y + i*50+hy);
                btnNameFilter[i].Name = $"btnNameFilter{i}";
                btnNameFilter[i].Size = new Size(btnWidth, btnHeight);
                btnNameFilter[i].Text = names[i];               
                Controls.Add(btnNameFilter[i]);              
                btnNameFilter[i].Click += new EventHandler(btnNameFilter_Click);

                //Panel[] panel = new Panel[count];
                //panel[i] = new Panel();
                //panel[i].BackColor = System.Drawing.Color.Transparent;
                //panel[i].Location = new Point(X * 2, Y + btnNameFilter[i].Height + interval);
                //panel[i].Name = $"{panel[i]}";
                //panel[i].Size = new Size(173, 0);
                //panel[i].Controls.Add(btnNameFilter[i]);
                //Controls.Add(panel[i]);
                //panel[i].Visible = false;

                //List<string> child = new List<string>();
                //var res_child = from b in collection
                //                where b.Name == btnNameFilter[i].Text
                //                select b.Children;

                //foreach (var item in res_child)
                //{
                //    foreach (var it in item)
                //    {
                //        child.Add(it.Name);
                //    }
                //}
                //count_child = child.Count();

                //foreach (var item in child)
                //{
                //    CheckBox chb = new CheckBox();
                //    chb.AutoSize = true;
                //    chb.Location = new System.Drawing.Point(1, dy1);
                //    chb.Size = new System.Drawing.Size(82, chb_height);
                //    chb.Text = item.ToString();
                //    chb.UseVisualStyleBackColor = true;
                //    btnNameFilter[i].Controls.Add(chb);
                //    // Зміщуємо виведення наступного чекбокса на його висоту + інтервал
                //    dy1 = dy1 + chb_height + interval;
                //}

                
                void btnNameFilter_Click(object sender, EventArgs e)
                {
                    //Panel pan = new Panel();                   
                    kol++;
                    //if ((sender as Button).Text != name)
                    //{
                    //    //kol = 1;

                    //}
                    var name = ((sender as Button).Text.ToString());
                  

                    if (kol % 2 != 0)
                    {
                       
                        pan = new Panel();                        
                        List<string> child = new List<string>();
                        var res_child = from b in collection
                                        where b.Name == (sender as Button).Text
                                        select b.Children;

                        //var namecheck = from n in collection
                        //                where n.Name == (sender as Button).Text
                        //                select n.Id;

                       if(res_child==null)
                        {
                            MessageBox.Show("Немає елементів для відображення");
                        }

                        //name = ((sender as Button).Text.ToString());
                        ////MessageBox.Show($"{name}");

                        foreach (var item in res_child)
                        {
                            foreach (var it in item)
                            {
                                child.Add(it.Name);
                            }
                        }
                        count_child = child.Count();

                        pan.Location = new Point(X,btnHeight*i+interval*2);
                        pan.Size = new Size(btnWidth, 10);
                        pan.BackColor = Color.Transparent;
                        pan.AutoScroll = true;
                        Controls.Add(pan);
                        pan.Visible = true;
                        dy1 = 0;
                        foreach (var item in child)
                        {
                            CheckBox chb = new CheckBox();
                            chb.AutoSize = true;
                            chb.Location = new System.Drawing.Point(1, dy1);
                            chb.Size = new System.Drawing.Size(82, chb_height);
                            chb.Text = item.ToString();
                            chb.CheckedChanged += CheckChangedHandler;
                            chb.Tag = item;
                            chb.UseVisualStyleBackColor = true;
                            pan.Controls.Add(chb);
                            // Зміщуємо виведення наступного чекбокса на його висоту + інтервал
                            dy1 = dy1 + chb_height + interval;

                        }
                       
                        var height = (chb_height+ interval)*count_child ;
                        pan.Height = height;                       
                       // hy = pan.Height;
                      
                    }
                    else
                    {
                        pan.Controls.Clear();
                        for (int i = 0; i < pan.Controls.Count; i++)
                        {
                            pan.Controls[i].Enabled = false;
                            pan.Controls[i].Dispose();
                            i--;
                        }
                        //MessageBox.Show($"{pan.Controls.Count}");

                        if (pan.Controls.Count == 0)
                        {                          
                                                     
                            Controls.Remove(pan);
                            pan.Dispose();                             
                            
                        }
                          //pan.Controls.RemoveByKey((sender as Button).Text);                   

                    }
                   
                }
            }

        }
        /// <summary>
        /// Ліст чекнутих елементів.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>

        private void CheckChangedHandler(object sender, EventArgs ea)
        {

            CheckBox cb = sender as CheckBox;


            //if (cb.Checked)
            //{
            //    string t=
            //    int x = Convert.ToInt32(cb.Tag);
            //    category.Add(x);   

            //    MessageBox.Show(cb.Text + " checked");                
            //}


            //var queryGroup = from g in _context..AsQueryable()
            //                 select g;

            var cat2 = GetListFilters();
                    

            //foreach (var item in cat2)
            //{
            //    category.Add(item);
            //    MessageBox.Show(item + " checked");
            //}

            //var res = from b in cat2

            //          where b == (sender as Button).Text              
            //          select b.Children;


            //if (cb.Checked)
            //{
                
            //    foreach (var y in res)
            //    {
            //        foreach (var item in y)
            //        {
                        
            //            category.Add(item.Id);
            //        }        
                                        

                    
            //    }
            //}

           
            






        }


        private void btn_add_element_Click(object sender, EventArgs e)
        {
            new AddNew().ShowDialog();
        }

        private void btn_find_Click(object sender, EventArgs e)
        {


           
            var filtersList = GetListFilters();
            int[] filterValueSearchList = category.ToArray();

            var query = _context
                    .Products
                    .AsQueryable();

            foreach (var fName in filtersList)
            {
                int countFilter = 0; //Кількість співпадінь у даній групі фільтрів
                var predicate = PredicateBuilder.False<Product>();
                foreach (var fValue in fName.Children)
                {
                    for (int i = 0; i < filterValueSearchList.Length; i++)
                    {
                        var idV = fValue.Id; //id - значення фільтра
                        if (filterValueSearchList[i] == idV) //маємо співпадіння
                        {
                            predicate = predicate
                                .Or(p => p.Filters
                                    .Any(f => f.FilterValueId == idV));
                            countFilter++;
                        }
                    }
                }
                if (countFilter != 0)
                    query = query.Where(predicate);
            }

            var listProduct = query.ToList();
            dgv_products.Rows.Clear();
            foreach (var p in listProduct)
            {
                object[] row =
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    null,                    
                };
                dgv_products.Rows.Add(row);
            }


        }

        //private void DynamicFill(List<FilterNameModel> model)
        //{
        //    Button btnNameFilter;
        //    CheckedListBox clbValuesFilter;
        //    Panel p;
        //    int dy = 15;
        //    //int y = 20;

        //    foreach (var item in model)
        //    {

        //        btnNameFilter = new Button();           
        //        btnNameFilter.BackColor = System.Drawing.SystemColors.ScrollBar;
        //        btnNameFilter.Location = new Point(10, dy);
        //        btnNameFilter.Name = $"btnNameFilter{item.Id}";
        //        btnNameFilter.Size = new Size(125, 48);
        //        btnNameFilter.Text = item.Name;
        //        btnNameFilter.Tag = item;             
        //        btnNameFilter.UseVisualStyleBackColor = false;
        //        Controls.Add(btnNameFilter);
        //        btnNameFilter.Click += new System.EventHandler(ButtonName_Click);
        //        ResumeLayout(false);
        //        PerformLayout();


        //        clbValuesFilter = new CheckedListBox();               
        //        clbValuesFilter.Name = $"clbValuesFilter{item.Id}";
        //        clbValuesFilter.Width = 150;
        //        clbValuesFilter.Location = new System.Drawing.Point(0, 45);
        //        clbValuesFilter.Size = new Size(150, 22);                      
        //        btnNameFilter.Controls.Add(clbValuesFilter);

        //        foreach (var child in item.Children)
        //        {
        //            clbValuesFilter.Items.Add(child);
        //        }
        //        dy += btnNameFilter.Size.Height + 30;

        //        p = new Panel();
        //        p.Tag = item.Children;
        //        p.Size = new Size(clbValuesFilter.Size.Width, clbValuesFilter.Size.Height+10);
        //        p.Controls.Add(clbValuesFilter);
        //        Controls.Add(p);
        //    }
        //}

        //private void ButtonName_Click(object sender, EventArgs e)
        //{
        //    var button = (sender as Button);

        //    //якщо кнопка натиснута
        //    //if (button != null)
        //    //{

        //    //    var height = checkedList.Height + 30;
        //    //    panel.Height = height;
        //    //}
        //    //else
        //    //{

        //    //    var height = checkedList.Height;
        //    //    panel.Height = height;
        //    //}            


        //}


    }
}
