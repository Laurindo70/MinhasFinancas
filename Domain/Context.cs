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
                .Property(u => u.Senha)
                .HasMaxLength(255)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Nome)
                .HasMaxLength(150)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.AtivaPorEmail)
                .HasDefaultValue(false);
            modelBuilder.Entity<User>()
                .Property(u => u.ContaAtivada)
                .HasDefaultValue(true);
            modelBuilder.Entity<User>()
                .Property(u => u.CriadoEm)
                .HasDefaultValueSql("now()");
        }
    }
}
