using System.Data.Entity.ModelConfiguration;
using CompanyApp.Domain.Entity;

namespace CompanyApp.Infrastructure.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            ToTable("user");

            HasKey(x => x.PK_User_Id);

            Property(x => x.User_Name).IsRequired();
            Property(x => x.User_Password).IsRequired();
        }
    }
}
