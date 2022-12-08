using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category : Entity
{
    
    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

 
    public virtual ICollection<Blogs> Blogs { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<SubCategory> SubCategories { get; set; }
    public virtual ExtendedUser User { get; set; }

    public Category()
    {
        State = true;
        Blogs = new HashSet<Blogs>();
        Products = new HashSet<Product>();
        SubCategories = new HashSet<SubCategory>();
    }

    public Category(int id, int? userId, int? emendatorAdminId, string categoryName, string description, string imgUrl, bool state) : base(id)
    {
        UserId = userId;
        EmendatorAdminId = emendatorAdminId;
        CategoryName = categoryName;
        Description = description;
        ImgUrl = imgUrl;
        State = state;
    }
}