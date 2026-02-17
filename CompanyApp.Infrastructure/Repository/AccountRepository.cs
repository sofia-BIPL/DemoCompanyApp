using System.Collections.Generic;
using System.Linq;
using CompanyApp.Domain.Entity;
using CompanyApp.Infrastructure.Context;

namespace CompanyApp.Infrastructure.Repository
{
    public class AccountRepository
    {
        public void SaveAccount(AccountEntity entity)
        {
            using (var context = new AppDbContext())
            {
                context.Accounts.Add(entity);
                context.SaveChanges();
            }
        }

        public List<AccountEntity> GetAccounts(int compId, int userId)
        {
            using (var context = new AppDbContext())
            {
                if (userId == 0)
                {
                    return context.Accounts
                        .Where(x => x.FK_Comp_Id == compId)
                        .ToList();
                }

                return context.Accounts
                    .Where(x => x.FK_Comp_Id == compId
                    && x.FK_User_Id == userId)
                    .ToList();
            }
        }
    }
}
