using Core.Persistence.Paging;
using Application.Features.ProductSliders.Dtos;

namespace Application.Features.ProductSliders.Models
{
    public class ProductSliderListModel : BasePageableModel
    {
        public IList<ProductSliderListDto> Items { get; set; }
    }
}
