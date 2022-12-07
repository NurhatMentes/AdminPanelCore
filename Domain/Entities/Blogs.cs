using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Blogs : Entity
{
    public Blogs()
    {
        Comments = new HashSet<Comment>();
    }

    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual Category Categories { get; set; }
    public virtual SubCategory SubCategories { get; set; }
    public virtual ExtendedUser User { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}