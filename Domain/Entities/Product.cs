using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class Product : Entity
{
    public Product()
    {
        this.Comments = new HashSet<Comment>();
        this.ProductSliders = new HashSet<ProductSlider>();
    }

    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public Nullable<int> SubCategoryId { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public Nullable<double> OldPrice { get; set; }
    public Nullable<int> Stock { get; set; }
    public string Color { get; set; }
    public string File { get; set; }
    public string Content { get; set; }
    public System.DateTime Date { get; set; }
    public Nullable<System.DateTime> UpdateDate { get; set; }
    public Nullable<int> EmendatorAdminId { get; set; }
    public string Tag { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual Category Categories { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual SubCategory SubCategories { get; set; }
    public virtual ExtendedUser Users { get; set; }
    public virtual ICollection<ProductSlider> ProductSliders { get; set; }
}