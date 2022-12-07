using Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserLog : Entity
{
    public int UserId { get; set; }
    public string State { get; set; }
    public DateTime? LogDate { get; set; }

    public virtual ExtendedUser User { get; set; }
}