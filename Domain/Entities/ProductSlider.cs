using Core.Persistence.Repositories;

namespace Domain.Entities;

public partial class ProductSlider : Entity
{
    public int SliderId { get; set; }
    public int ProductId { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual Product Products { get; set; }
}