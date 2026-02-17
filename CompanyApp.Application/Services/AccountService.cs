/*
    This class contains business logic related to Accounts.

    It handles:
    - Saving new accounts
    - Loading accounts based on CompanyId
    - Loading accounts user-wise after login

    If no user is logged in (UserId = 0),
    it loads all accounts of the company.

    If user is logged in,
    it loads only accounts created by that user.

    It uses Global Session variables
    to fetch current CompanyId and UserId.

    Flow:
    View → ViewModel → DTO → AccountService → Mapper → Repository → DB
*/
using System.Collections.Generic;
using CompanyApp.Domain.DTO;
using CompanyApp.Domain.Entity;
using CompanyApp.Domain.GlobalVar;
using CompanyApp.Infrastructure.Repository;
using CompanyApp.Application.Mapper;

namespace CompanyApp.Application.Services
{
    public class AccountService
    {
        private AccountRepository _accountRepo;

        public AccountService()
        {
            _accountRepo = new AccountRepository();
        }

        public void SaveAccount(AccountDTO dto)
        {
            dto.FK_Comp_Id = SessionGlobal.Comp_Id;
            dto.FK_User_Id = SessionGlobal.User_Id;

            AccountEntity entity = AccountMapper.MapToEntity(dto);
            _accountRepo.SaveAccount(entity);
        }

        public List<AccountEntity> GetAccounts()
        {
            int compId = SessionGlobal.Comp_Id;
            int userId = SessionGlobal.User_Id;

            return _accountRepo.GetAccounts(compId, userId);
            /* Inside repository:
              if userId == 0 → show all accounts
                   else → show user wise accounts
            */
        }
    }
}

