/*
    PURPOSE OF MAPPER:

    In Clean Architecture, Presentation Layer sends DTO objects
    but Repository Layer works with Entity objects.

    Even if DTO and Entity have same structure,
    UI must NOT directly send Entity to Infrastructure.

    Mapper converts DTO → Entity before saving into DB.

    Flow:
    View → ViewModel → DTO → Service → Mapper → Entity → Repository → DB
*/
using System.Collections.Generic;
using CompanyApp.Domain.DTO;
using CompanyApp.Domain.Entity;
using CompanyApp.Domain.GlobalVar;
using CompanyApp.Infrastructure.Repository;
using CompanyApp.Application.Mapper;

namespace CompanyApp.Application.Services
{
    public class CompanyService
    {
        private CompanyRepository _companyRepo;

        //constructor to initialise repostiory object, ensures _companyRepo ≠ null
        public CompanyService()
        {
            _companyRepo = new CompanyRepository();
        }

        //accepts companydto from presentation layer
        public void SaveCompany(CompanyDTO dto)
        {
            CompanyEntity entity = CompanyMapper.MapToEntity(dto); //converts dto to entity using mapper
            _companyRepo.SaveCompany(entity);
        }

        public List<CompanyEntity> GetAllCompanies()
        {
            return _companyRepo.GetAllCompanies();
        }

        public void OpenCompany(int companyId)
        {
            SessionGlobal.Comp_Id = companyId; //So other modules (like UserService, AccountService) can access current company context.
        }

        public void CloseCompany()
        {
            SessionGlobal.Comp_Id = 0; //no company is active
            SessionGlobal.User_Id = 0; //no user is logged in
        }
    }
}

