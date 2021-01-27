using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuizForm
{
    public partial class ResForm : Form
    {        
            public ResForm(QuizForm form)
            {
                InitializeComponent();
                label1.Text = $"Кількість правильних відповідей: {f.positive}";
                label2.Text = $"Кількість неправильних відповідей: { f.negative - f.positive}";
                InitializeComponent();

             }
          
        
    }
}
