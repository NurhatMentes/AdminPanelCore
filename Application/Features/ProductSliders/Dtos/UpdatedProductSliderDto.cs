namespace Application.Features.ProductSliders.Dtos;

public class UpdatedProductSliderDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }
}