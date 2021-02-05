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

        private readonly MyContext context;

        /// <summary>
        /// Поточне питання.
        /// </summary>
        private int indexQuestion = 0;        

        /// <summary>
        /// Кількість питань у тестах
        /// </summary>
        int cou = 0;

        /// <summary>
        /// Масив булевих значень відповідей.
        /// </summary>
        private bool[] result;

        /// <summary>
        /// Айді останньої створеної сесії після логіна користувача.
        /// </summary>
        private readonly int sesmax;

        /// <summary>
        /// Лічильник правильних відповідей.
        /// </summary>
        private int q;
      
        /// <summary>
        /// Для таймера інтервал секунд.
        /// </summary>
        private int _tick;

        /// <summary>
        /// Лічильник тіків таймера.
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Властивість,що містить айді користувача
        /// </summary>
        public User LogInstancem { get; set; }

       /// <summary>
       /// Властивіть,що містить айді останньої сесії.
       /// </summary>
        public int idsession
        {
            get
            {
                return sesmax;
            }

            set
            {
                value = sesmax;
            }
        }

        /// <summary>
        /// Властивість,кількість тіків.
        /// </summary>
        public int count_tick { get; set; }

        /// <summary>
        /// Правильні відповіді.
        /// </summary>
        public int positive
        {
            get
            {                
                return q;
            }
            set
            {
                value = positive;
            }
        }


        /// <summary>
        /// Неправильні відповіді.
        /// </summary>
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

        
        public QuizForm()
        {
            context = new MyContext();
            LoginForm log = new LoginForm();
            if (log.ShowDialog() == DialogResult.OK)
            {
                LogInstancem = log.UserInstance;
                               
                var sess = new Session
                {
                    UserId = LogInstancem.Id,
                    Begin = DateTime.Now,
                    //End = DateTime.Now.AddSeconds(count_tick),
                    Marks = 80M

                };              

                context.Sessions.Add(sess);
                context.SaveChanges();    
                            

            }

            var info = context.Sessions.Max(x => x.Id);
            sesmax = info;

            _listQuestions = context.Questions.Select(x => new QuizModel
                {
                    Text = x.Text,
                    Answers = x.Answers.Select(y => new QuizAnswerModel
                    {
                        Id=y.Id,
                        Text = y.Text,
                        IsTrue = y.IsTrue
                    }
                    ).ToList()
                }).ToList();
            
            InitializeComponent();
            timer1.Start();
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
                RadioButton gb;
                gb = new System.Windows.Forms.RadioButton();
                gb.AutoSize = true;
                gb.Location = new System.Drawing.Point(25, startPosition);
                gb.Name = $"gbItem{i}";
                gb.Tag = answers[i];
                gb.Size = new System.Drawing.Size(67, 19);
                gb.TabIndex = 1;
                gb.TabStop = true;
                gb.Text = answers[i].Text;
                gb.UseVisualStyleBackColor = true;
                groupBox1.Controls.Add(gb);
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
            q = 0;   
            
            var radioButtons = groupBox1.Controls.OfType<RadioButton>();
            foreach (RadioButton rb in radioButtons)
            {               
                if (rb.Checked)
                {                  
                    var answer = rb.Tag as QuizAnswerModel;
                    result[indexQuestion] = answer.IsTrue;
                  
                    var infoid = context.Answers.Where(x => x.Id == answer.Id).ToList();
                    foreach (var item in infoid)
                    {
                        context.Results.Add(new Result { SessionId = idsession, AnswerId = item.Id });
                        context.SaveChanges();
                    }                    

                }    
                                 
                
            }

            foreach (var item in result)
            {
                if (item == true)
                {
                    q++;
                }
            }

            indexQuestion++;  
            
            if (_listQuestions.Count() == indexQuestion)
            {
                //Close();  
                var total = context.Sessions.Where(x => x.Id == sesmax).ToList();
                //Додала в таблицю Сесія,скільки часу було потрачено на тест і записала в базу.
                foreach (var item in total)
                {
                    item.End = DateTime.Now.AddSeconds(count_tick);                  
                    context.SaveChanges();
                }
                count_tick = count;
                new ResForm(this).ShowDialog();
            }
            else
            {
                LoadQuestion();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ResForm(this).ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _tick++;
            textBox1.Text = _tick.ToString();
            count++;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
