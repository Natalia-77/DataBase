using Microsoft.EntityFrameworkCore;
using Quiz.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuizForm
{
    public partial class ResForm : Form
    {
        
        public User UserInst { get; set; }
        public ResForm(QuizForm form)
            {

            InitializeComponent();
            label1.Text = $"Кількість правильних відповідей: {form.positive}";
            label2.Text = $"Кількість неправильних відповідей: { form.negative - form.positive}";
            label3.Text = $"Відсоток правильних відповідей: {(form.positive * 100) / form.negative}";

            UserInst = form.LogInstancem;
           // InitializeComponent();

            }

        
        public void SessionData_Load(object sender, EventArgs e)
        {           
            MyContext context = new MyContext();           
            var info = context.Sessions
               .Where(x => x.UserId == UserInst.Id)
               .Select(x => new
               {
                   Id = x.Id,
                   Name = x.User.Name,
                   Surname = x.User.Surname,
                   Begin = x.Begin,
                   End = x.End,
               }).ToList();

            foreach (var item in info)
            {
                object[] row = 
                       {$"{item.Id}",
                        $"{item.Name}",
                        $"{item.Surname}",                       
                        $"{item.Begin}",
                        $"{item.End}"

                    };

                dataGridView1.Rows.Add(row);

            }
        }
          
        
    }
}
