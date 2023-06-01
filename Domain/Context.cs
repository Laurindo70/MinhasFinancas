using Microsoft.EntityFrameworkCore;

namespace MinhasFinancas.Domain
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<User> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(255)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(150)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Activated_by_email)
                .HasDefaultValue(false);
            modelBuilder.Entity<User>()
                .Property(u => u.Account_activated)
                .HasDefaultValue(true);
            modelBuilder.Entity<User>()
                .Property(u => u.Created_at)
                .HasDefaultValueSql("now()");
        }


    }
}
