using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class SiteIdentity : Entity
{
    public int IdentityId { get; set; }
    public Nullable<int> EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Keywords { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
    public Nullable<bool> State { get; set; }

    public virtual ExtendedUser Users { get; set; }
}