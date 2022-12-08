using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class AboutUs:Entity
    {
        public int? UserId { get; set; }
        public int? EmendatorAdminId { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public virtual ExtendedUser User { get; set; }

        public AboutUs()
        {
            
        }
        public AboutUs(int userId, int? emendatorAdminId, string description, bool state)
        {
            UserId = userId;
            EmendatorAdminId = emendatorAdminId;
            Description = description;
            State = state;
        }
    }
}
