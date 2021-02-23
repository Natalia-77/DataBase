using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TreeViewForm.Entities
{
    [Table("Cosmetic")]

    public class Cosmetic
    {
        [Key]
        public int Id { get; set; }
        
        [Required,StringLength (255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string UrlSlug { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public virtual Cosmetic Parent { get; set; }


    }
}
