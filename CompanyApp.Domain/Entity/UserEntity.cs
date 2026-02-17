namespace CompanyApp.Domain.Entity
{
    public class UserEntity
    {
        public int PK_User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public int FK_Comp_Id { get; set; }
    }
}
