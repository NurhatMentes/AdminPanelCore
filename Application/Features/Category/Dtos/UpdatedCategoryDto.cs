namespace Application.Features.Category.Dtos;

public class UpdatedCategoryDto
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }
}