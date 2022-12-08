using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Slider : Entity
{
    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual ExtendedUser User { get; set; }

    public Slider(int id, DateTime creationTime, int userId, int? emendatorAdminId, string title, string description, string imgUrl, bool state) : base(id, creationTime)
    {
        UserId = userId;
        EmendatorAdminId = emendatorAdminId;
        Title = title;
        Description = description;
        ImgUrl = imgUrl;
        State = state;
    }

    public Slider()
    {
        State = true;
    }
}