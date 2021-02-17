using FormRoles.ImageResize;
using FormRoles.Service;
using Roles.DAL;
using Roles.DAL.Service;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FormRoles
{
    
    public partial class AddNewUser : Form
    {
        public string file_name { get; set; }
        private string file_selected = string.Empty;
        MyContext context = new MyContext();
        public AddNewUser()
        {
            InitializeComponent();
        }
        private void AddNewUser_Load(object sender, EventArgs e)
        {
            label7.Text = "Оберіть фото:";
            foreach (var role in context.Roles)
            {
                RoleComboBoxItem item = new RoleComboBoxItem
                {
                    Id = role.Id,
                    Name = role.Name
                };
                comboBox1.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(file_selected))
            {
                string ext = Path.GetExtension(file_selected);

                string fileName = Path.GetRandomFileName() + ext;

                string fileSavePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "images", fileName);

                var bmp = ResizeImage.ResizeOrigImg(
                    new Bitmap(Image.FromFile(file_selected)), 75, 75);

                bmp.Save(fileSavePath, ImageFormat.Jpeg);

                file_name = fileName;
            }
            context.Users
               .Add(
               new User
               {   
                   Image= file_name,
                   Name = textBox1.Text,
                   Surname = textBox2.Text,
                   Login = textBox3.Text,
                   Password = PassHash.HashPassword(textBox4.Text)
                  
               });

            context.SaveChanges();

            var infoid = context.Users.Max(x => x.Id);
            var item = comboBox1.SelectedItem;
            if (item != null)
            {
                var rol = comboBox1.SelectedItem as RoleComboBoxItem;
                
                context.UserRoles
                   .Add(new UserRoles
                   {
                       UserId = infoid,
                       RoleId = rol.Id
                   }); 
                context.SaveChanges();              

            }            
           
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
                    pictureBox1.Image = image;
                    file_selected = dlg.FileName;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Неможливо відкрити!");
                }
            }
        }
    }
}
