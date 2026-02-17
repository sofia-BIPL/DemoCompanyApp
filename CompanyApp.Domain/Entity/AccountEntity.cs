namespace CompanyApp.Domain.Entity
{
    public class AccountEntity
    {
        public int PK_Acc_Id { get; set; }
        public string Acc_Name { get; set; }
        public string Acc_Group { get; set; }
        public decimal Acc_Balance { get; set; }
        public int FK_User_Id { get; set; }
        public int FK_Comp_Id { get; set; }
    }
}
