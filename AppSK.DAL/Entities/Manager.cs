using AppSK.DAL.Entities.Base;

namespace AppSK.DAL.Entities
{
    public class Manager : Person
    {
        public User User { get; set; }

        public string UserId { get; set; }

        public string CompanyName { get; set; }
    }
}
