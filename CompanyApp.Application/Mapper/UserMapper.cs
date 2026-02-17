using CompanyApp.Domain.DTO;
using CompanyApp.Domain.Entity;

namespace CompanyApp.Application.Mapper
{
    public static class UserMapper
    {
        public static UserEntity MapToEntity(UserDTO dto)
        {
            return new UserEntity()
            {
                PK_User_Id = dto.PK_User_Id,
                User_Name = dto.User_Name,
                User_Password = dto.User_Password,
                FK_Comp_Id = dto.FK_Comp_Id
            };
        }
    }
}
