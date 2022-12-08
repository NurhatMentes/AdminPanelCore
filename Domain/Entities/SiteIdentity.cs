using Core.Persistence.Repositories;

namespace Domain.Entities;

public class SiteIdentity : Entity
{
    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Keywords { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
    public bool? State { get; set; }

    public virtual ExtendedUser User { get; set; }


    public SiteIdentity()
    {
        State = true;
    }

    public SiteIdentity(int id, DateTime creationTime, int? emendatorAdminId, string title, string keywords, string description, string logoUrl, bool? state, int? userId) : base(id, creationTime)
    {
        EmendatorAdminId = emendatorAdminId;
        Title = title;
        Keywords = keywords;
        Description = description;
        LogoUrl = logoUrl;
        State = state;
        UserId = userId;
    }

}