using System;
using System.Collections.Generic;
using System.Text;

namespace QuizForm.Model
{
    
        /// <summary>
        /// Питання
        /// </summary>
        public class QuizModel
        {
            public string Text { get; set; }
            public List<QuizAnswerModel> Answers { get; set; }
        }

        /// <summary>
        /// Варіанти відповіді
        /// </summary>
        public class QuizAnswerModel
        {
        public int Id { get; set; }
            public string Text { get; set; }
            public bool IsTrue { get; set; }
        }

   

}
