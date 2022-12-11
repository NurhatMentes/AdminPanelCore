using Core.Persistence.Paging;
using Application.Features.Category.Dtos;

namespace Application.Features.Category.Models
{
    public class CategoryListModel : BasePageableModel
    {
        public IList<CategoryListDto> Items { get; set; }
    }
}
