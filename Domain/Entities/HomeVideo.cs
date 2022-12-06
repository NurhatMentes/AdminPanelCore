using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class HomeVideo : Entity
{
    public int HomeVideoId { get; set; }
    public Nullable<int> EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoUrl { get; set; }

    public virtual ExtendedUser Users { get; set; }
}