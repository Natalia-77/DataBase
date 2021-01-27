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
                label1.Text = $"Кількість правильних відповідей: {form.positive}";
                label2.Text = $"Кількість неправильних відповідей: { form.negative - form.positive}";
                InitializeComponent();

             }
          
        
    }
}
