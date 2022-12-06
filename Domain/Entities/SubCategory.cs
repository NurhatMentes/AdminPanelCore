using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class SubCategory : Entity
{
    public SubCategory()
    {
        this.Blogs = new HashSet<Blogs>();
        this.Products = new HashSet<Product>();
    }

    public int SubCategoryId { get; set; }
    public Nullable<int> UserId { get; set; }
    public Nullable<int> EmendatorAdminId { get; set; }
    public Nullable<int> CategoryId { get; set; }
    public string SubCategoryName { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual ICollection<Blogs> Blogs { get; set; }
    public virtual Category Categories { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public virtual ExtendedUser Users { get; set; }
}