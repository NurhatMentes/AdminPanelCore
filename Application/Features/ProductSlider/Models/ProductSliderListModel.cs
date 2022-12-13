using Core.Persistence.Paging;
using Application.Features.ProductSlider.Dtos;

namespace Application.Features.ProductSlider.Models
{
    public class ProductSliderListModel : BasePageableModel
    {
        public IList<ProductSliderListDto> Items { get; set; }
    }
}
