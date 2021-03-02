using FilterShop.Entities;
using FilterShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FilterShop
{
    public partial class Form1 : Form
    {
        private readonly MyContext _context;
        public IQueryable<FilterName> filter { get; set; }       

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
            clb1.Items.Clear();
            GetListFilters();
            foreach (var item in filter)
            {
                comboBox1.Items.Add(item.Name);
                
            }
            
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
    }
}
