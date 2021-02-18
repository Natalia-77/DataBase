﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeViewForm.Entities;
using TreeViewForm.ModelTree;

namespace TreeViewForm
{
    public partial class Form1 : Form
    {
        private readonly MyContext _context;
        public Form1()
        {
            InitializeComponent();
            _context = new MyContext();
            Load_Tree();
        }

        public void Load_Tree()
        {
            try
            {
                
                //ParentId==null,бо це і є батьківські вузли.
                var res = _context.Categories.OrderBy(d => d.Name).Where(c => c.ParentId == null);
                var list=res.Select(r=>new ModelTreeView
                {
                    Id = r.Id,
                    Name=r.Name,
                    ParentId=r.ParentId
                });

                foreach (var c in list)
                {
                    TreeNode node = new TreeNode();
                    node.Text = c.Name;                 
                    //node.Name = c.Name;
                    node.Tag = c;                   
                    node.Nodes.Add("");
                    tvCategory.Nodes.Add(node);
                }

            }
            catch(Exception)
            {
                throw new Exception("Error");
            }
        }
        /// <summary>
        /// Add category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Category category = new Category
            {
                Name = tbCategory.Text,
                ParentId = null
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            ModelTreeView model = new ModelTreeView
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId
            };
            TreeNode node = new TreeNode();
            node.Text = tbCategory.Text;
            node.Name = Guid.NewGuid().ToString();
            //node.Name = tbCategory.Text;
            node.Tag = model;
            tvCategory.Nodes.Add(node);
        }
    }
}
