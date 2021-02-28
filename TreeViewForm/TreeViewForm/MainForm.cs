using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TreeViewForm.Helpers;
using TreeViewForm.Entities;
using TreeViewForm.Models;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;

namespace TreeViewForm
{
    public partial class MainForm : Form
    {
        private readonly MyContext _context;
        public MainForm()
        {
            InitializeComponent();
            _context = new MyContext();
            DbSeeder.SeedDatabase(_context);           

        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            var list = _context.Cosmetics.Where(x => x.ParentId == null)
                .Select(x => new CosmeticVM
                {
                    Id=x.Id,
                    Name=x.Name,
                    Image=x.Image,
                    UrlSlug=x.UrlSlug

                }).ToList();

            foreach (var item in list)
            {
                AddParent(item);
            }
            tvCategory.Focus();
        }

        private void AddParent(CosmeticVM cosmetic)
        {
            TreeNode node = new TreeNode();
            node.Text = cosmetic.Name;
            node.Name = cosmetic.Id.ToString();
            node.Tag = cosmetic;           
            node.Nodes.Add("");
            tvCategory.Nodes.Add(node);

        }

        private void AddChild(TreeNode parent, CosmeticVM cosmetic)
        {
            TreeNode node = new TreeNode();
            node.Text = cosmetic.Name;
            node.Name = cosmetic.Id.ToString();
            node.Tag = cosmetic;          
            node.Nodes.Add("");         
            parent.Nodes.Add(node);

        }

        private void tvCategory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "")
            {
                var parent = e.Node;
                var parentId = (parent.Tag as CosmeticVM).Id;
                parent.Nodes.Clear();
                var list = _context.Cosmetics
                .Where(x => x.ParentId == parentId)
                .Select(x => new CosmeticVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlSlug = x.UrlSlug,
                    Image = x.Image,
                   
                }).ToList();

                foreach (var item in list)
                {
                    AddChild(parent,item);
                }

            }
        }

        /// <summary>
        /// Додавання через форму батьківського елемента дерева.
        /// </summary>
        public void AddParentDataBase()
        {
            Cosmetic cosmet = new Cosmetic
            {
                Name = tbParent.Text,
                ParentId = null,
                UrlSlug = tbUrl.Text
            };
            _context.Cosmetics.Add(cosmet);
            _context.SaveChanges();          

        }

        /// <summary>
        /// Додавання через форму дочірнього елемента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddChildNode(TreeNode parent, string namechild,string url_name)
        {
            var model = (CosmeticVM)parent.Tag;
            Cosmetic cosmet = new Cosmetic
            {
                Name = namechild,
                ParentId = model.Id,
                UrlSlug = url_name
            };
            _context.Cosmetics.Add(cosmet);
            _context.SaveChanges();
        }

        /// <summary>
        /// Редагування обраного елемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public void Edit(TreeNode edit, string new_name)
        {       
                      
            var res = _context.Cosmetics.SingleOrDefault(x => x.Name == edit.Text);
            res.Name = new_name;            
            _context.SaveChanges();

        }

        /// <summary>
        /// Видалення елемента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        public void DeleteNode(TreeNode node)
        {
            //======НЕ РОБОЧИЙ ВАРІАНТ=======================

            //var model = (CosmeticVM)node.Tag;
            //var category = _context.Cosmetics
            //    .SingleOrDefault(c => c.Id == model.Id);

            //if (category != null)
            //{               
            //        //якщо кількість дочірніх вузлів==0
            //        if (node.Nodes.Count == 0)
            //        {
            //        _context.Cosmetics.Remove(category);

            //        }
            //}
            //_context.SaveChanges();
            //========================================


            //Оголосила ліст,де буде зберігатись елементи дерева на видалення.
            var node_for_del = new List<Cosmetic>();

            var model = (CosmeticVM)node.Tag;
            var category = _context.Cosmetics
                .SingleOrDefault(c => c.Id == model.Id);
            
            if (category != null)
            {
               
                //Записую в оголошений ліст видалення батька.
                node_for_del.Add(category);

                //шукаю дітей відповідного батька по ParentId.
                var child = _context.Cosmetics.Where(c => c.ParentId == category.Id).ToList();

                //якщо у батька є діти.
                if(child.Count!=0)
                {
                    //створила екземпляр класа Queue<T>
                    var tree = new Queue<IList<Cosmetic>>();

                    //помістила в чергу знайдених дітей.
                    tree.Enqueue(child);

                    //все,що буде відповідати умові,буде поміщено в чергу.Потім при додаванні в Ліст елементів 
                    //призначеного для видалення,буду знімати з черги.
                    while(tree.Count!=0)
                    {
                        //В IList потрапить елемент,який знімаю з черги.
                        IList<Cosmetic> c = tree.Dequeue();

                        //Додала в Ліст для видалення елементи.
                        node_for_del.AddRange(c);

                        //Вглиб пошук підкатегорій,для який батьками є вище знайдені діти.
                        foreach ( Cosmetic chi in c)
                        {
                            child = _context.Cosmetics.Where(t => t.ParentId == chi.Id).ToList();
                            if(child.Count!=0)
                            {
                                //записую в чергу,якщо відповідає умові.
                                tree.Enqueue(child);
                            }
                        }
                    }
                }

                foreach (Cosmetic item in node_for_del)
                {
                    _context.Cosmetics.Remove(item);
                }
                
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Search in TreeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        List<TreeNode> treenew = new List<TreeNode>();
        void Find(TreeNodeCollection Nodes, string str)
        {

            foreach (TreeNode node in Nodes)
            {
                if (node.Text.ToLower().Contains(str.ToLower()) && node.Nodes.Count != 0)
                    treenew.Add(node);
                if (node.Nodes.Count > 0)
                    Find(node.Nodes, str);
            }

        }

        private TreeNode SearchTreeView(string str, TreeNodeCollection p_Nodes)
        {
            foreach (TreeNode node in p_Nodes)
            {
                if (node.Text.ToLower().Contains(str.ToLower()))
                    return node;

                if (node.Nodes.Count > 0)
                {
                    TreeNode child = SearchTreeView(str, node.Nodes);
                    if (child != null) return child;
                }
            }

            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbParent.Text) && !string.IsNullOrEmpty(tbUrl.Text))
            {
                AddParentDataBase();
            }
            else
            {
                MessageBox.Show("Заповніть всі обов\"язкові поля");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(tvCategory.SelectedNode!=null)
            {
                if (!string.IsNullOrEmpty(tbChild.Text) && !string.IsNullOrEmpty(tbChildurl.Text))
                {
                    AddChildNode(tvCategory.SelectedNode, tbChild.Text, tbChildurl.Text);
                }
                else
                {
                    MessageBox.Show("Заповніть всі обов\"язкові поля");
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(tvCategory.SelectedNode!=null)
            {
               
               if(!string.IsNullOrEmpty(tbEdit.Text))
               {
                    Edit(tvCategory.SelectedNode, tbEdit.Text);
               }
                else
                {
                    MessageBox.Show("Заповніть всі обов\"язкові поля");
                }
                // var name = tvCategory.SelectedNode.Text;
                // MessageBox.Show(name);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // tvCategory.SelectedNode.Nodes.Remove(tvCategory.SelectedNode);

            if (tvCategory.SelectedNode != null)
            {
                DeleteNode(tvCategory.SelectedNode);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tvCategory.Nodes.Clear();
            MainForm_Load(sender,e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            TreeNode resultNode = SearchTreeView(tbSearch.Text, tvCategory.Nodes);

            if (resultNode != null)
            {
                
            }
        }
    }
}
