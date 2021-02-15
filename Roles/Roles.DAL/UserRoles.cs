﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Roles.DAL
{
    [Table("tblUsersRoles")]
    public class UserRoles
    {
       [Key]
        public int Id { get; set; }
        public int UserId { get; set; }      
        public int RoleId { get; set; }

        public virtual User User{ get; set; }
        public virtual Role Role { get; set; }

        //public override string ToString()
        //{
        //    return UserId.ToString();
        //}
    }
}
