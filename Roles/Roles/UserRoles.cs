using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Roles
{
    [Table("tblUsersRoles")]
    public class UserRoles
    {
        //[Key]
        //public int Id { get; set; }

        //[ForeignKey("UserId")]
        public int UserId { get; set; }

       // [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public virtual User User{ get; set; }
        public virtual Role Role { get; set; }
    }
}
