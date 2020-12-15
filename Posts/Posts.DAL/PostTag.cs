﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Posts.DAL
{
    [Table("tblPostTag")]

    public class PostTag
    {
        
        [ForeignKey("Post")]
        public int PostId { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }  

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }





    }
}
