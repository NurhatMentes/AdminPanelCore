using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductSlider : Entity
{
  
    public int ProductId { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

    public virtual Product Product { get; set; }

    public ProductSlider()
    {
        
    }
    public ProductSlider(int id, DateTime creationTime, int productId, string imgUrl, bool state) : base(id, creationTime)
    {
        ProductId = productId;
        ImgUrl = imgUrl;
        State = state;
    }

}