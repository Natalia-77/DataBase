using Microsoft.EntityFrameworkCore;


namespace FilterShop.Entities
{
    public class MyContext : DbContext
    {
        public DbSet<FilterName> FilterNames { get; set; }
        public DbSet<FilterValue> FilterValues { get; set; }
        public DbSet<FilterNameGroup> FilterNameGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=nataliadb;Username=natalia;Password=$544$B77w**G)K$t!Ube22}77b");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilterNameGroup>(filterNG =>
            {
                filterNG.HasKey(f => new
                {
                    f.FilterValueId,
                    f.FilterNameId
                });

                filterNG.HasOne(ur => ur.FilterNameOf)
                    .WithMany(r => r.FilterNameGroups)
                    .HasForeignKey(ur => ur.FilterNameId)
                    .IsRequired();

                filterNG.HasOne(ur => ur.FilterValueOf)
                                .WithMany(r => r.FilterNameGroups)
                                .HasForeignKey(ur => ur.FilterValueId)
                                .IsRequired();
            });
        }
    }
}
