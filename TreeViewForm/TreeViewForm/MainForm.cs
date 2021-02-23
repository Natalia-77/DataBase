using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TreeViewForm.Helpers;
using TreeViewForm.Entities;
using TreeViewForm.Models;

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
                AddChildNode(tvCategory.SelectedNode,tbChild.Text,tbChildurl.Text);
            }
        }
    }
}
