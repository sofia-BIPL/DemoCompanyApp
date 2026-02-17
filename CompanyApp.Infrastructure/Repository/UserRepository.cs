using System.Collections.Generic;
using System.Linq;
using CompanyApp.Domain.Entity;
using CompanyApp.Infrastructure.Context;

namespace CompanyApp.Infrastructure.Repository
{
    public class UserRepository
    {
        public void SaveUser(UserEntity entity)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Add(entity);
                context.SaveChanges();
            }
        }

        public List<UserEntity> GetUsersByCompanyId(int companyId)
        {
            using (var context = new AppDbContext())
            {
                return context.Users
                    .Where(x => x.FK_Comp_Id == companyId)
                    .ToList();
            }
        }

        public UserEntity GetUser(string username, int companyId)
        {
            using (var context = new AppDbContext())
            {
                return context.Users
                    .FirstOrDefault(x => x.User_Name == username
                    && x.FK_Comp_Id == companyId);
            }
        }

        // Check if a user with the given username already exists for the company
        public bool UserExists(string username, int companyId)
        {
            using (var context = new AppDbContext())
            {
                return context.Users
                    .Any(x => x.User_Name == username && x.FK_Comp_Id == companyId);
            }
        }
    }
}
