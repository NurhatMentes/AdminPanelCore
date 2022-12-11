using Core.Persistence.Paging;
using Application.Features.Product.Dtos;

namespace Application.Features.Product.Models
{
    public class ProductListModel: BasePageableModel
    {
        public IList<ProductListDto> Items { get; set; }
    }
}
