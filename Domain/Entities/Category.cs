using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class Category : Entity
{

    public Category()
    {
        this.State = true;
        this.Blogs = new HashSet<Blogs>();
        this.Products = new HashSet<Product>();
        this.SubCategories = new HashSet<SubCategory>();
    }

    public int CategoryId { get; set; }
    public Nullable<int> UserId { get; set; }
    public Nullable<int> EmendatorAdminId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual ICollection<Blogs> Blogs { get; set; }
    public virtual ExtendedUser Users { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<SubCategory> SubCategories { get; set; }
}