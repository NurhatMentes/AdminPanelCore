using Core.Persistence.Repositories;

namespace Domain.Entities;

public class SubCategory : Entity
{
    public SubCategory()
    {
        Blogs = new HashSet<Blogs>();
        Products = new HashSet<Product>();
    }

    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public int? CategoryId { get; set; }
    public string SubCategoryName { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual ICollection<Blogs> Blogs { get; set; }
    public virtual Category Categories { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public virtual ExtendedUser User { get; set; }
}