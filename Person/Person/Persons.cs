﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Person
{
    [Table ("tblPerson")]

    public class Persons
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Surname { get; set; }

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        [Range(10, 120)]
        public int Weight { get; set; }

        [Required]
        [Range(33, 47)]
        public int Footsize { get; set; }

        //[Required]
        public byte Point { get; set; }
    }
}
