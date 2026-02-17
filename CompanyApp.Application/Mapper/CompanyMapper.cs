using CompanyApp.Domain.DTO;
using CompanyApp.Domain.Entity;

namespace CompanyApp.Application.Mapper
{
    public static class CompanyMapper
    {
        public static CompanyEntity MapToEntity(CompanyDTO dto)
        {
            return new CompanyEntity()
            {
                PK_Comp_Id = dto.PK_Comp_Id,
                Comp_Name = dto.Comp_Name,
                Comp_GSTIN = dto.Comp_GSTIN,
                Comp_Country = dto.Comp_Country,
                Comp_State = dto.Comp_State
            };
        }
    }
}
