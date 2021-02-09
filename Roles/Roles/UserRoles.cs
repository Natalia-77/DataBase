using System.ComponentModel.DataAnnotations.Schema;


namespace Roles
{
    [Table("tblUsersRoles")]
    public class UserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual User User{ get; set; }
        public virtual Role Role { get; set; }
    }
}
