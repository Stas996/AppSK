namespace AppSK.DAL.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool IsNew => Id == 0;
    }
}
