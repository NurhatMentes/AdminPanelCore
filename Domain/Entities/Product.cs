using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Product : Entity
{
    public Product()
    {
        Comments = new HashSet<Comment>();
        ProductSliders = new HashSet<ProductSlider>();
    }

    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public double? OldPrice { get; set; }
    public int? Stock { get; set; }
    public string Color { get; set; }
    public string File { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int? EmendatorAdminId { get; set; }
    public string Tag { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual Category Categories { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual SubCategory SubCategories { get; set; }
    public virtual ExtendedUser User { get; set; }
    public virtual ICollection<ProductSlider> ProductSliders { get; set; }
}