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
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=nataliadb;Username=natalia;Password=$544$B77w**G)K$t!Ube22}77b");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>().HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRoles>()
           .HasOne<User>(user => user.User)
           .WithMany(s => s.UserRoless)
           .HasForeignKey(user => user.UserId).IsRequired();

            modelBuilder.Entity<UserRoles>()
           .HasOne<Role>(role => role.Role)
           .WithMany(s => s.UserRoless)
           .HasForeignKey(role => role.RoleId).IsRequired();
        }

    }
}
