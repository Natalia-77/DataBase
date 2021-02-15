using Microsoft.EntityFrameworkCore;
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
    public partial class EditForm : Form
    {
        private readonly int _id;
        private readonly MyContext _context;
        public EditForm(int id)
        {
            InitializeComponent();
            _id = id;
            _context = new MyContext();
            DataEdit();
        }

        private void DataEdit()
        {
            label1.Text = "Оберіть посаду:";
            //var list = _context.Roles.ToArray();
            //cbRoles.Items.AddRange(list);

            //var post = _context.Users
            //    .SingleOrDefault(p => p.Id == _id);

            //foreach (var item in _context.Roles)
            //{
            //    cbRoles.Items.Add(item);
            //    if (item.Id == post.Id)
            //        cbRoles.SelectedItem = item;
            //}

            //textBox1.Text = post.Surname;

            var post = _context.UserRoles
                .SingleOrDefault(p => p.Id == _id);
            

            foreach (var item in _context.Roles)
            {
                cbRoles.Items.Add(item);
                if (item.Id == post.RoleId)
                {
                    cbRoles.SelectedItem = item;
                   
                }
               
                
            }
            //textBox1.Text = post.UserId.ToString();
            var res = _context.Users.Where(p => p.Id == post.UserId);
            foreach (var items in res)
            {
                textBox1.Text = items.Surname;
            }

        }
    }
}
