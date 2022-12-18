using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Blog : Entity
{
    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Keywords { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual Category Categories { get; set; }
    public virtual SubCategory SubCategories { get; set; }
    public virtual ExtendedUser User { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }

    public Blog(int? userId, int? emendatorAdminId, int categoryId, int? subCategoryId, string title, string content, string imgUrl, bool state)
    {
        UserId = userId;
        EmendatorAdminId = emendatorAdminId;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        Title = title;
        Content = content;
        ImgUrl = imgUrl;
        State = state;
    }

    public Blog()
    {
        Comments = new HashSet<Comment>();
        State = true;
    }
}