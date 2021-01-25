﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quiz
{
    
        [Table("tblQuest")]
        public class Quest
        {
            [Key]
            public int Id { get; set; }

            [Required, StringLength(1000)]
            public string Text { get; set; }

            public virtual ICollection<Answer> Answers { get; set; }

        }

    
}
