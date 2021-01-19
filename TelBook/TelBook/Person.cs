using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static Bogus.DataSets.Name;

namespace TelBook
{
    [Table("tblPerson")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Surname { get; set; }

        [Required]
        public string Number { get; set; }

        
    }
}
