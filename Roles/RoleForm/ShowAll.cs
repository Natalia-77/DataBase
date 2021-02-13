using Microsoft.EntityFrameworkCore;
using Roles.DAL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FormRoles
{
    public partial class ShowAll : Form
    {
       // public string valuerow { get; set; }
        private MyContext _context = new MyContext();
        public ShowAll()
        {
            InitializeComponent();
        }

        public void Data_Load(object sender, EventArgs e)
        {
            MyContext context = new MyContext();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            label2.Text = "Введіть прізвище користувача,якого потрібно видалити:";
            var info = context.UserRoles.Include(u => u.User).Include(rol=>rol.Role).AsQueryable();

            var list = info.Select(r => new 
            {
                Id = r.User.Id,
                Name = r.User.Name,
                Surname = r.User.Surname,                
                //Roles = r.RoleId,
                Roles=r.Role.Name
              

            }).AsQueryable();       
            
            foreach (var item in list)
            {
                object[] row =
                       {$"{item.Id}",
                        $"{item.Name}",
                        $"{item.Surname}",                         
                        $"{item.Roles}"
                    };

                dataGridView1.Rows.Add(row);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string stroka =dataGridView1.CurrentCell.Value.ToString();            
           // label5.Text = str;
           // valuerow = stroka;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            User d = _context.Users.SingleOrDefault(x => x.Surname == surname);
            if (d != null)
            {
                _context.Users.Remove(d);
                _context.SaveChanges();

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
    }
}
