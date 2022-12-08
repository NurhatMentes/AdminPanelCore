using Core.Persistence.Repositories;

namespace Domain.Entities;

public class SubCategory : Entity
{
    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public int? CategoryId { get; set; }
    public string SubCategoryName { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual ICollection<Blogs> Blogs { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public virtual Category Categories { get; set; }
    public virtual ExtendedUser User { get; set; }

    public SubCategory(int id, DateTime creationTime, int? userId, int? emendatorAdminId, int? categoryId, string subCategoryName, string imgUrl, bool state) : base(id, creationTime)
    {
        UserId = userId;
        EmendatorAdminId = emendatorAdminId;
        CategoryId = categoryId;
        SubCategoryName = subCategoryName;
        ImgUrl = imgUrl;
        State = state;
    }

    public SubCategory()
    {
        State = true;
        Blogs = new HashSet<Blogs>();
        Products = new HashSet<Product>();
    }
}