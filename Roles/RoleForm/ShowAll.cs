using Microsoft.EntityFrameworkCore;
using Roles.DAL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FormRoles
{
    public partial class ShowAll : Form
    {       
        private readonly MyContext _context;
        public ShowAll()
        {
            InitializeComponent();
            _context = new MyContext();
            DataLoad();
            dataGridView1.Height = 350;
        }       

        private void DataLoad()
        {
            label2.Text = "Редагування по курсору в гріді";
                      
            var query = _context.UserRoles.AsQueryable();

            var list = query.Select(x => new {
                Id = x.Id,               
                Image=x.User.Image,
                Name = x.User.Name,
                Surname = x.User.Surname,
                Roles = x.Role.Name
            })
                .AsQueryable().ToList();

          
            foreach (var item in list)
            {
                //Шлях до зображення.
                string path_file = Path.Combine(Directory.GetCurrentDirectory(), "Images",item.Image);

                using (var imgStream = File.OpenRead(path_file))
                {                      

                    object[] row =
                      {
                       item.Id,
                       item.Image==null ? null:Image.FromStream(imgStream),
                       item.Name,
                       item.Surname,
                       item.Roles
                    };

                    dataGridView1.Rows.Add(row);
                }
               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {          

            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            //строчка,на якій курсор стоїть в гріді.
            int grid_item=dataGridView1.SelectedCells[0].RowIndex;

            //видаляю з гріда.
            dataGridView1.Rows.RemoveAt(grid_item);

            //видаляю з бази.
            User d = _context.Users.SingleOrDefault(x => x.Id == id);
            if (d != null)
            {
                _context.Users.Remove(d);
                _context.SaveChanges();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Якщо ми обрали потрібну строчку в гріді.
            if (dataGridView1.CurrentRow != null)
            {
                // Id обраної строчки в гріді.
                int id_select_item = int.Parse(dataGridView1["ColId", dataGridView1.CurrentRow.Index].Value.ToString());

                //натискаю кнопку редагування і викликаю форму для редагування.
                EditForm dlg = new EditForm(id_select_item);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DataLoad();                    
                }
            }
           
        }
    }
}
