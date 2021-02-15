using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Roles.DAL
{
    [Table("tblRoles")]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<UserRoles> UserRoless { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
