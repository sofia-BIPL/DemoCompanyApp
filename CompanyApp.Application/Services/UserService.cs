/*    This class contains business logic related to Users.

    It handles:
    - Saving new users
    - Checking if any user exists in selected company
    - Authenticating user login (username + password)

    It receives UserDTO from Presentation Layer,
    converts DTO → Entity using Mapper,
    and interacts with Repository for DB operations.

    It also sets Global UserId after successful login.

    Flow:
    View → ViewModel → DTO → UserService → Mapper → Repository → DB
*/
using System.Collections.Generic;
using CompanyApp.Domain.DTO;
using CompanyApp.Domain.Entity;
using CompanyApp.Domain.GlobalVar;
using CompanyApp.Infrastructure.Repository;
using CompanyApp.Application.Mapper;

namespace CompanyApp.Application.Services
{
    public class UserService
    {
        private UserRepository _userRepo;

        public UserService()
        {
            _userRepo = new UserRepository();
        }

        public void SaveUser(UserDTO dto)
        {
            dto.FK_Comp_Id = SessionGlobal.Comp_Id; //Injecting currently opened company id into DTO
            UserEntity entity = UserMapper.MapToEntity(dto);
            _userRepo.SaveUser(entity); //saving to db
        }

        // Check if a username already exists for the current company
        public bool CheckIfUsernameExists(string username)
        {
            return _userRepo.UserExists(username, SessionGlobal.Comp_Id);
        }

        // to decide: Login Page or Dashboard directly.
        public bool CheckIfUserExists(int companyId)
        {
            List<UserEntity> users = _userRepo.GetUsersByCompanyId(companyId);
            return users.Count > 0;
        }

        // Get all users for the currently opened company
        public List<UserEntity> GetAllUsers()
        {
            return _userRepo.GetUsersByCompanyId(SessionGlobal.Comp_Id);
        }

        public string Authenticate(string username, string password, int companyId)
        {
            UserEntity user = _userRepo.GetUser(username, companyId);

            if (user == null)
            {
                return "Username Wrong";
            }

            if (user.User_Password != password)
            {
                return "Password Wrong";
            }

            SessionGlobal.User_Id = user.PK_User_Id; //Store logged-in user id globally
                                                     //for: Account Creation, User - wise Filtering
            return "Success";
        }
    }
}

