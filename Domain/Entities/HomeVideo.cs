using Core.Persistence.Repositories;

namespace Domain.Entities;

public class HomeVideo : Entity
{
    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoUrl { get; set; }

    public virtual ExtendedUser User { get; set; }

    public HomeVideo()
    {
    }
    public HomeVideo(int id, DateTime creationTime, int? emendatorAdminId, string title, string description, string videoUrl, int? userId) : base(id, creationTime)
    {
        EmendatorAdminId = emendatorAdminId;
        Title = title;
        Description = description;
        VideoUrl = videoUrl;
        UserId = userId;
    }
}