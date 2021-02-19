using System;
using System.Data;
using System.Linq;
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
            tvCategory.MouseDoubleClick += treeView1_MouseDoubleClick;
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
                    node.Name = c.Name;
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
        /// Додавання category
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
            node.Name = tbCategory.Text;
            node.Tag = model;
            tvCategory.Nodes.Add(node);
        }


        // Обробний подвійного натискання мишки
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Отримали вузол.
            TreeNode node = tvCategory.SelectedNode;

            // Вікно
            MessageBox.Show(string.Format("Ви обрали : {0}", node.Text));
        }


        /// <summary>
        /// Додавання дочірньої ноди.
        /// </summary>
        /// <param name="parentroot"></param>
        /// <param name="nameNode"></param>
        public void AddNodeChild(TreeNode parentroot,string nameNode)
        {
            var model = (ModelTreeView)parentroot.Tag;
            Category category = new Category
            {
                Name = nameNode,
                ParentId = model.Id
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            TreeNode node = new TreeNode();
            node.Text = nameNode;            
            node.Tag = new ModelTreeView
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId
            };
            parentroot.Nodes.Add(node);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Чкщо у нас є обраний вузол,куди додається дочірня нода.

            if (tvCategory.SelectedNode != null)
            {
                AddNodeChild(tvCategory.SelectedNode, tbCategory.Text);
            }
               
        }

        public TreeNode GetAllNodes(TreeNode parent)
        {
            var model = (ModelTreeView)parent.Tag;
            var query = from c in _context.Categories
                        where c.ParentId == model.Id
                        orderby c.Name
                        select new ModelTreeView
                        {
                            Id = c.Id,
                            Name = c.Name,
                            ParentId = c.ParentId
                        };
            parent.Nodes.Clear();
            foreach (var c in query)
            {
                TreeNode node = new TreeNode();
                node.Text = c.Name;
                //node.Name = Guid.NewGuid().ToString();
                node.Tag = c;               
                node.Nodes.Add("");
                parent.Nodes.Add(node);
            }
            return parent;
        }

        private void Before(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node= GetAllNodes(e.Node);
        }
    }
}
