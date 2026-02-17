/*

    In Clean Architecture, Presentation Layer sends DTO objects
    but Repository Layer works with Entity objects.

    Even if DTO and Entity have same structure,
    UI must NOT directly send Entity to Infrastructure.

    Mapper converts DTO → Entity before saving into DB.

    Flow:
    View → ViewModel → DTO → Service → Mapper → Entity → Repository → DB
*/

using CompanyApp.Domain.DTO;
using CompanyApp.Domain.Entity;

namespace CompanyApp.Application.Mapper
{
    public static class AccountMapper
    {
        public static AccountEntity MapToEntity(AccountDTO dto)
        {
            return new AccountEntity()
            {
                PK_Acc_Id = dto.PK_Acc_Id,
                Acc_Name = dto.Acc_Name,
                Acc_Group = dto.Acc_Group,
                Acc_Balance = dto.Acc_Balance,
                FK_User_Id = dto.FK_User_Id,
                FK_Comp_Id = dto.FK_Comp_Id
            };
        }
    }
}
