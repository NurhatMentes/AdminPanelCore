using Core.Persistence.Repositories;

namespace Domain.Entities;

public class HomeVideo : Entity
{
    public int? EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoUrl { get; set; }

    public virtual ExtendedUser User { get; set; }
}