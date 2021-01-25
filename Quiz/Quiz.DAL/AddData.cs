using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz
{
    public static class AddData
    {
        public static void AddAll(MyContext context)
        {
            AddQuestion(context);
           //AddAnswer(context);
        }
        private static void AddQuestion(MyContext context)
        {
            if (context.Questions.Count() == 0)
            {
                var question = new Quest
                {
                    Text = "Скільки кольорів має райдуга?",
                };

                context.Questions.Add(question);
                context.SaveChanges();
                var answers = new List<Answer>
                {
                    new Answer {Text="3",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="5",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="25",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="7",IsTrue=true,QuestionId=question.Id}

                };
                context.Answers.AddRange(answers);
                context.SaveChanges();
                question = new Quest
                {
                    Text = "Де вперше зафіксований Ковід 19?",
                };

                context.Questions.Add(question);
                context.SaveChanges();
                answers = new List<Answer>
                {
                    new Answer {Text="США",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Росія",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="ЮАР",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Китай",IsTrue=true,QuestionId=question.Id}

                };
                context.Answers.AddRange(answers);
                context.SaveChanges();
                question = new Quest
                {
                    Text = "Хто став 46 президентом США?",
                };

                context.Questions.Add(question);
                context.SaveChanges();
                answers = new List<Answer>
                {
                    new Answer {Text="Обама",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Путін",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Меркель",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Байден",IsTrue=true,QuestionId=question.Id}

                };
                context.Answers.AddRange(answers);
                context.SaveChanges();
                question = new Quest
                {
                    Text = "Що печуть на день народження?",
                };

                context.Questions.Add(question);
                context.SaveChanges();
                answers = new List<Answer>
                {
                    new Answer {Text="Кекс",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Пряники",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Вафлі",IsTrue=false,QuestionId=question.Id},
                    new Answer {Text="Святковий торт",IsTrue=true,QuestionId=question.Id}
                };
                context.Answers.AddRange(answers);
                context.SaveChanges();


            }

        }



    }
}
