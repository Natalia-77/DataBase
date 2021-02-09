using Microsoft.EntityFrameworkCore;


namespace Roles
{
    public class MyContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=dbblog;Username=userblog;Password=$544idkeuIDOKEKDds(Kdues9dfsuiio$B5rd@dddss542G)K$t!Ube22}xk");
        }

    }
}
