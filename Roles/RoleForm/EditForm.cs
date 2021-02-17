using FormRoles.ImageResize;
using Microsoft.EntityFrameworkCore;
using Roles.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormRoles
{
    public partial class EditForm : Form
    {
        private readonly int _id;
        private readonly MyContext _context;
        private string fileSelected = string.Empty;
        private string file_old { get; set; }
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
            var res = _context.Users.Where(p => p.Id == post.UserId);
            foreach (var items in res)
            {
                textBox1.Text = items.Surname;
                textBox2.Text = items.Name;
            }
                     

            //Шлях до конкретного зображення.
            string dirImagePath = Path.Combine(Directory.GetCurrentDirectory(),"Images");

            //Якщо такої папки у вказаному шляху не існує,то створюємо її.
            if (!Directory.Exists(dirImagePath))
            {
                Directory.CreateDirectory(dirImagePath);
            }

            //Якщо є зображення,то завантажуємо в пікчербокс відповідне зображення по вказаному шляху.
            if (!string.IsNullOrEmpty(post.User.Image))
            {
                var dir = Path.Combine(Directory.GetCurrentDirectory(),
                    "Images", post.User.Image);

                var imgStream = File.OpenRead(dir);
                
                    pictureBox1.Image = Image.FromStream(imgStream);
                file_old = dir;
                imgStream.Close();
                
                
                //pictureBox1.Image = Image.FromFile(dir);
               
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var post = _context.UserRoles
               .SingleOrDefault(p => p.Id == _id);

            post.RoleId = (cbRoles.SelectedItem as Role).Id;
            post.User.Surname = textBox1.Text;
            post.User.Name = textBox2.Text;

            if (!string.IsNullOrEmpty(fileSelected))
            {
                File.Delete(file_old);

                string extension = Path.GetExtension(fileSelected);

                string fileName = Path.GetRandomFileName() + extension;

                string fileSavePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "images", fileName);

                var bmp = ResizeImage.ResizeOrigImg(
                    new Bitmap(Image.FromFile(fileSelected)), 75, 75);
                bmp.Save(fileSavePath, ImageFormat.Jpeg);              
                post.User.Image = fileName;              
               
            }
           
            _context.SaveChanges();
           
            DialogResult = DialogResult.OK;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap image;
            OpenFileDialog dlg = new OpenFileDialog(); 

            dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;" +
                "*.PNG|All files (*.*)|*.*"; 

            if (dlg.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                   
                    image = new Bitmap(dlg.FileName);                   
                   // pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    fileSelected = dlg.FileName;
                    
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Неможливо відкрити!");
                }


            }
        }
    }
}


