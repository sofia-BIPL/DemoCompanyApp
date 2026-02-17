using System.Data.Entity.ModelConfiguration;
using CompanyApp.Domain.Entity;

namespace CompanyApp.Infrastructure.Configuration
{
    public class AccountConfiguration : EntityTypeConfiguration<AccountEntity>
    {
        public AccountConfiguration()
        {
            ToTable("account");

            HasKey(x => x.PK_Acc_Id);

            Property(x => x.Acc_Name).IsRequired();
            Property(x => x.Acc_Group).IsRequired();
            Property(x => x.Acc_Balance).IsRequired();
        }
    }
}
