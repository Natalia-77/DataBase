﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Posts.DAL
{
    [Table("tblCategory")]

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(150)]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
