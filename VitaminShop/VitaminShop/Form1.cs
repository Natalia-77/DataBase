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
       
        public Form1()
        {
            InitializeComponent();
            _context = new MyContext();
            //_context = context;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            AutoScroll = true;
            SuspendLayout();
            DbSeeder.SeedDatabase(_context);
            var filters = GetListFilters();
            DynamicFill(filters);
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

        private void DynamicFill(List<FilterNameModel>model)
        {
            Button btnNameFilter;
            CheckedListBox clbValuesFilter;
            int dy = 15;
           
            foreach (var item in model)
            {
                btnNameFilter = new Button();
               // clbValuesFilter = new CheckedListBox();
                //btnNameFilter.SuspendLayout();
                btnNameFilter.BackColor = System.Drawing.SystemColors.ScrollBar;
                btnNameFilter.Location = new System.Drawing.Point(10, dy);
                btnNameFilter.Name =$"btnNameFilter{item.Id}";
                btnNameFilter.Size = new System.Drawing.Size(125, 48);               
                btnNameFilter.Text = item.Name;
                Controls.Add(btnNameFilter);
                ResumeLayout(false);
                PerformLayout();
                btnNameFilter.UseVisualStyleBackColor = false;
                //btnNameFilter.Click += new System.EventHandler(this.button1_Click);
                dy += btnNameFilter.Height + 15;
            }
            
           
        }

    }
}
