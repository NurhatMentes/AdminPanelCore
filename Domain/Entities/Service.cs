using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Service : Entity
{

    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Keywords { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual ExtendedUser User { get; set; }

    public Service()
    {
        State=true;
    }

    public Service(int id, DateTime creationTime, int? userId, int? emendatorAdminId, string title, string description, string keywords, string imgUrl, bool state) : base(id, creationTime)
    {
        UserId = userId;
        EmendatorAdminId = emendatorAdminId;
        Title = title;
        Description = description;
        Keywords = keywords;
        ImgUrl = imgUrl;
        State = state;
    }

}