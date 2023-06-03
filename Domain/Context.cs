using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.TabelsOfRelation;

namespace MinhasFinancas.Domain
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<Account> Contas { get; set; }
        public DbSet<UserAsAccount> UsuarioConta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TABELA USUARIOS
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Activated_by_email)
                .HasDefaultValue(false);
            modelBuilder.Entity<User>()
                .Property(u => u.Account_activated)
                .HasDefaultValue(true);
            modelBuilder.Entity<User>()
                .Property(u => u.Created_at)
                .HasDefaultValueSql("now()");

            // TABELA CONTAS
            modelBuilder.Entity<Account>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Account>()
                .Property(a => a.Available_value)
                .HasDefaultValue(0);
            modelBuilder.Entity<Account>()
                .Property(a => a.Value_credit)
                .HasDefaultValue(0);
            modelBuilder.Entity<Account>()
                .Property(u => u.Created_at)
                .HasDefaultValueSql("now()");
            modelBuilder.Entity<User>()
                .HasMany(u => u.Users_account)
                .WithOne(a => a.User)
                .HasForeignKey(e => e.Responsible_user)
                .IsRequired();

            // TABELA CONTAS E USUARIOS
            modelBuilder.Entity<User>()
                .HasMany(a => a.Accounts)
                .WithMany(u => u.Users)
                .UsingEntity<UserAsAccount>(
                    l => l.HasOne<Account>().WithMany().HasForeignKey(e => e.Account_id),
                    r => r.HasOne<User>().WithMany().HasForeignKey(e => e.User_id));
        }


    }
}
