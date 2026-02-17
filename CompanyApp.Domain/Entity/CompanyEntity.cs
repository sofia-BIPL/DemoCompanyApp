namespace CompanyApp.Domain.Entity
{
    public class CompanyEntity
    {
        public int  PK_Comp_Id { get; set; }
        public string Comp_Name { get; set; }
        public string Comp_GSTIN { get; set; }
        public string Comp_Country { get; set; }
        public string Comp_State { get; set; }
    }
}
