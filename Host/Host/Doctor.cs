
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Host
{
    [Table("tblDoctors")]
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required,StringLength(50)]
        public string Login { get; set; }

        [Required, StringLength(250)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public int Stage { get; set; }
        public virtual Department Department { get; set; }
    }
}
