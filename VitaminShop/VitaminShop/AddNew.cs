using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VitaminShop.Entetities;

namespace VitaminShop
{
    public partial class AddNew : Form
    {
        private readonly MyContext context; 
        public AddNew()
        {
            InitializeComponent();
            context = new MyContext();
            Load();
        }

        public void Load()
        {
            lbl_title_parent.Text = "Введіть назву категорії для додавання:";
            lbl_addchild.Text = "Оберіть категорію:";

            //Додаю значення назв категорій в комбобокс.
            //var queryName = from f in _context.FilterNames.AsQueryable() select f.Name;

            var results = from b in context.FilterNames.AsQueryable()
                        select b.Name;

            //Додаю в комбобокс.
            foreach (var item in results)
            {
                cb_parents.Items.Add(item);
            }


        }

        private void btn_addparent_Click(object sender, EventArgs e)
        {
            context.FilterNames.Add(
                new FilterName
                {
                    Name = tb_add_parent.Text
                });
            context.SaveChanges();
            Close();
        }

        private void btn_addchild_Click(object sender, EventArgs e)
        {
            context.FilterValues.Add(
                            new FilterValue
                            {
                                Name = tb_newchild.Text
                                //Name = cb_name_parent.SelectedItem.ToString()
                            });
            context.SaveChanges();

            var nId = context.FilterNames
                        .SingleOrDefault(fname => fname.Name == cb_parents.SelectedItem.ToString()).Id;
            var vId = context.FilterValues
                .SingleOrDefault(fvalue => fvalue.Name == tb_newchild.Text).Id;
            if (context.FilterNameGroups
                       .SingleOrDefault(f => f.FilterValueId == vId &&
                       f.FilterNameId == nId) == null)
            {
                context.FilterNameGroups.Add(
                            new FilterNameGroup
                            {
                                FilterNameId = nId,
                                FilterValueId = vId
                            });
                context.SaveChanges();
            }
        }
    }
}
