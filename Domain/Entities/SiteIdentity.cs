using Core.Persistence.Repositories;

namespace Domain.Entities;

public class SiteIdentity : Entity
{
    public int? EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Keywords { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
    public bool? State { get; set; }

    public virtual ExtendedUser User { get; set; }
}