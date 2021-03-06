﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz.DAL
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

            if (context.Users.Count() == 0)
            {
                var user = new User
                {
                    Name = "Петро",
                    Surname = "Гончарук",
                    Login = "petro",
                    Password = "123"
                };

                context.Users.Add(user);
                context.SaveChanges();

                var session = new List<Session>
                {
                    new Session{UserId=user.Id,Begin=DateTime.Now,End=DateTime.Now.AddMinutes(12),Marks=72M}

                };
                context.Sessions.AddRange(session);
                context.SaveChanges();

                var res = new List<Result>
                {
                    new Result{SessionId=1,AnswerId=4},
                    new Result{SessionId=1,AnswerId=5},
                    new Result{SessionId=1,AnswerId=9},
                    new Result{SessionId=1,AnswerId=13}                   
                };
                context.Results.AddRange(res);
                context.SaveChanges();

            }

        }

    }
}
