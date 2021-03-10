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

        int kol  = 0;

        Panel pan;

        public int hy { get; set; }

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
                Button[] btnNameFilter = new Button[count];
                btnNameFilter[i] = new Button();
                btnNameFilter[i].Location = new Point(X, Y + i*50);
                btnNameFilter[i].Name = $"btnNameFilter{i}";
                btnNameFilter[i].Size = new Size(125, 48);
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
                        var namecheck = from n in collection
                                        where n.Name == (sender as Button).Text
                                        select n.Id;
                        MessageBox.Show($"{namecheck.Count()}");
                        name = ((sender as Button).Text.ToString());

                        MessageBox.Show($"{name}");

                        foreach (var item in res_child)
                        {
                            foreach (var it in item)
                            {
                                child.Add(it.Name);
                            }
                        }
                        count_child = child.Count();

                        int fy = 50;
                        fy += 50;
                        pan.Location = new Point(10,fy);
                        pan.Size = new Size(150, 0);
                        pan.BackColor = Color.Red;
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
                            chb.UseVisualStyleBackColor = true;
                            pan.Controls.Add(chb);
                            // Зміщуємо виведення наступного чекбокса на його висоту + інтервал
                            dy1 = dy1 + chb_height + interval;

                        }
                        //MessageBox.Show($"{pan.Controls.Count}");
                        var height = 2 * chb_height * (count_child - 1) + interval;
                        pan.Height = height;
                        //MessageBox.Show($"{pan.Height}");
                        hy = pan.Height;
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
                            
                            //MessageBox.Show("disp");
                            // pan.Controls.RemoveByKey((sender as Button).Text);                           
                            Controls.Remove(pan);
                            pan.Dispose();                             
                            
                        }
                          //pan.Controls.RemoveByKey((sender as Button).Text);                   

                    }
                }
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
