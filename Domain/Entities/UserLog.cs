using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class UserLog : Entity
{
    public int UserLogId { get; set; }
    public int UserId { get; set; }
    public string State { get; set; }
    public Nullable<System.DateTime> LogDate { get; set; }

    public virtual ExtendedUser Users { get; set; }
}