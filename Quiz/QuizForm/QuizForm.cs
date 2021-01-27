using Quiz.DAL;
using QuizForm.Model;
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
    public partial class QuizForm : Form
    {
        /// <summary>
        /// Питання.
        /// </summary>
        private List<QuizModel> _listQuestions;

        /// <summary>
        /// Поточне питання.
        /// </summary>
        private int indexQuestion = 0;

        int cou = 0;
        /// <summary>
        /// Масив булевих значень відповідей.
        /// </summary>
        private bool[] result;

        public int positive
        {
            get
            {
                return int.Parse(label3.Text);
            }
            set
            {
                value = positive;
            }
        }

        public int negative
        {
            get
            {
                return _listQuestions.Count();
            }
            set
            {
                value = _listQuestions.Count();
            }
        }
        public QuizForm(MyContext context)
        {

           // _listQuestions = new List<QuizModel>();
           _listQuestions= context.Questions.Select(x => new QuizModel
            {
                Text = x.Text,
                Answers = x.Answers.Select(y => new QuizAnswerModel
                {
                    Text=y.Text,
                    IsTrue=y.IsTrue
                }
                ).ToList()
            }).ToList();

            InitializeComponent();
            cou = context.Questions.Count();
            label2.Text = $"Загальна кількість питань:{cou}";
            result = new bool[_listQuestions.Count];
        }
        private void LoadQuestion()
        {
            label1.Text = _listQuestions[indexQuestion].Text;
            var answers = _listQuestions[indexQuestion].Answers;
            int dy = 25;
            int startPosition = 30;
            groupBox1.Controls.Clear();
            for (int i = 0; i < answers.Count; i++)
            {
                RadioButton gbOneItem;
                gbOneItem = new System.Windows.Forms.RadioButton();
                gbOneItem.AutoSize = true;
                gbOneItem.Location = new System.Drawing.Point(25, startPosition);
                gbOneItem.Name = $"gbItem{i}";
                gbOneItem.Tag = answers[i];
                gbOneItem.Size = new System.Drawing.Size(67, 19);
                gbOneItem.TabIndex = 1;
                gbOneItem.TabStop = true;
                gbOneItem.Text = answers[i].Text;
                gbOneItem.UseVisualStyleBackColor = true;
                groupBox1.Controls.Add(gbOneItem);
                startPosition += dy;
                label4.Text = $"Індекс питання:{indexQuestion + 1}";
            }



        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            LoadQuestion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Кількість правильних відповідей.
            int q = 0;
           
            var radioButtons = groupBox1.Controls.OfType<RadioButton>();
            foreach (RadioButton rb in radioButtons)
            {
                if (rb.Checked)
                {
                    var answer = rb.Tag as QuizAnswerModel;
                    result[indexQuestion] = answer.IsTrue;
                }
               
            }
            foreach (var item in result)
            {
                if (item == true)
                {
                    q++;
                }

            }

            label3.Text = $"Кількість правильних відповідей {q}";// q.ToString();            
            MessageBox.Show("Ви відповіли ", result[indexQuestion].ToString());
            indexQuestion++;

            if (_listQuestions.Count() == indexQuestion)
            {
                Close();
                new ResForm(this).ShowDialog();
            }
            else
            {
                LoadQuestion();
            }




        }
    }
}
