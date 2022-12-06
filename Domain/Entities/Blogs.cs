using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class Blogs : Entity
{
    public Blogs()
    {
        this.Comments = new HashSet<Comment>();
    }

    public int BlogId { get; set; }
    public Nullable<int> UserId { get; set; }
    public Nullable<int> EmendatorAdminId { get; set; }
    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual Category Categories { get; set; }
    public virtual SubCategory SubCategories { get; set; }
    public virtual ExtendedUser Users { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}