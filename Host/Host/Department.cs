using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Host
{
    [Table("tblDepartments")]
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int NumberCabinet { get; set; }
        
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
