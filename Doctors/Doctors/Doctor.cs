using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Doctors
{
    
        [Table("tblDoc")]

        public class Doctor
        {
            [Key]
            public int Id { get; set; }

            [Required, StringLength(100)]
            public string LastName { get; set; }

            [Required, StringLength(100)]
            public string FirstName { get; set; }

            [Required]
            public int Stage { get; set; }

            [ForeignKey("Department")]
            public int DepartmentId { get; set; }
           
            public virtual Department Department { get; set; }
        }
    
}
