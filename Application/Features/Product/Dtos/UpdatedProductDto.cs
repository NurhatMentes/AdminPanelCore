namespace Application.Features.Product.Dtos;

public class UpdatedProductDto
{
    public int Id { get; set; }
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

}