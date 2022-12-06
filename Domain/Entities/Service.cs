using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class Service : Entity
{
    public int ServiceId { get; set; }
    public Nullable<int> UserId { get; set; }
    public Nullable<int> EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tag { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual ExtendedUser Users { get; set; }
}