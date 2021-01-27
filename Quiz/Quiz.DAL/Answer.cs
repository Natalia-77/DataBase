using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quiz.DAL
{
    [Table("tblAnswer")]
    public class Answer
    {             
            [Key]
            public int Id { get; set; }

            [Required, StringLength(500)]
            public string Text { get; set; }

            public bool IsTrue { get; set; }

            [ForeignKey("Question")]
            public int QuestionId { get; set; }

            public virtual Quest Question { get; set; }
        

    }
}
