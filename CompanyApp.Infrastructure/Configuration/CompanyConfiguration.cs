using System.Data.Entity.ModelConfiguration;
using CompanyApp.Domain.Entity;

namespace CompanyApp.Infrastructure.Configuration
{
    public class CompanyConfiguration : EntityTypeConfiguration<CompanyEntity>
    {
        public CompanyConfiguration()
        {
            ToTable("company");

            HasKey(x => x.PK_Comp_Id);

            Property(x => x.Comp_Name).IsRequired();
            Property(x => x.Comp_GSTIN).IsRequired().HasMaxLength(15);
            Property(x => x.Comp_Country).IsRequired();
            Property(x => x.Comp_State).IsRequired();
        }
    }
}
