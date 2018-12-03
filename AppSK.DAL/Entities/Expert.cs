using AppSK.DAL.Entities.Base;

namespace AppSK.DAL.Entities
{
    public class Expert : Person
    {
        public User User { get; set; }

        public string UserId { get; set; }

        public int Activity { get; set; }
    }
}
