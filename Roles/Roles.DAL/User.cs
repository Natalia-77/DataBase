using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Roles.DAL
{
    [Table("tblUsers")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(150)]
        public string Surname { get; set; }

        [Required, StringLength(100)]
        public string Login { get; set; }

        [Required, StringLength(120)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public virtual ICollection<UserRoles> UserRoless { get; set; }
    }
}
