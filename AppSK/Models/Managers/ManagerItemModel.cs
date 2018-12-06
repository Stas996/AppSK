namespace AppSK.Models.Managers
{
    public class ManagerItemModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Fullname
        {
            get => $"{FirstName} {LastName}";
        }
    }
}