using System.Data.Entity;
using CompanyApp.Domain.Entity;
using CompanyApp.Infrastructure.Configuration;

namespace CompanyApp.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("CompanyDB")
        {
        }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new AccountConfiguration());
        }
    }
}
