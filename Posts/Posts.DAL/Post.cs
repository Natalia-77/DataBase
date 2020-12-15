using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Posts.DAL
{
    [Table("tblPost")]

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string ShortDescription { get; set; }

        [Required, StringLength(100)]
        public string Description { get; set; }

        public DateTime Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Modified { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
       
        public virtual ICollection<PostTag> PostTags { get; set; }

    }
}
