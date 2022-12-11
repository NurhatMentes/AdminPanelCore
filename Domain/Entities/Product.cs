using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Product : Entity
{
    public int CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public double? OldPrice { get; set; }
    public int? Stock { get; set; }
    public string Color { get; set; }
    public string File { get; set; }
    public string Content { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string Keywords { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual Category Categories { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual SubCategory SubCategories { get; set; }
    public virtual ExtendedUser User { get; set; }
    public virtual ICollection<ProductSlider> ProductSliders { get; set; }

    public Product(int id, DateTime creationTime, int categoryId, int? subCategoryId, int? userId, string title, double price, double? oldPrice, int? stock, string color, string file, string content, DateTime? updateDate, int? emendatorAdminId, string tag, string imgUrl, bool state) : base(id, creationTime)
    {
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        UserId = userId;
        Title = title;
        Price = price;
        OldPrice = oldPrice;
        Stock = stock;
        Color = color;
        File = file;
        Content = content;
        UpdateDate = updateDate;
        EmendatorAdminId = emendatorAdminId;
        Keywords = tag;
        ImgUrl = imgUrl;
        State = state;
    }

    public Product()
    {
        State = true;
        Comments = new HashSet<Comment>();
        ProductSliders = new HashSet<ProductSlider>();
    }

}