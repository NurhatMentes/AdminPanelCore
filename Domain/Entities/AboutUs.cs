using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class AboutUs:Entity
    {
        public int? UserId { get; set; }
        public int? EmendatorAdminId { get; set; }
        public string Description { get; set; }
        public bool? State { get; set; }

        public virtual ExtendedUser User { get; set; }
    }
}
