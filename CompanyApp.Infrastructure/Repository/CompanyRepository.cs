using System.Collections.Generic;
using System.Linq;
using CompanyApp.Domain.Entity;
using CompanyApp.Infrastructure.Context;

namespace CompanyApp.Infrastructure.Repository
{
    public class CompanyRepository
    {
        public void SaveCompany(CompanyEntity entity)
        {
            using (var context = new AppDbContext())
            {
                context.Companies.Add(entity);
                context.SaveChanges();
            }
        }

        public List<CompanyEntity> GetAllCompanies()
        {
            using (var context = new AppDbContext())
            {
                return context.Companies.ToList();
            }
        }
    }
}
