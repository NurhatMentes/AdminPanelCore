using Core.Persistence.Paging;
using Application.Features.Categories.Dtos;

namespace Application.Features.Categories.Models
{
    public class CategoryListModel : BasePageableModel
    {
        public IList<CategoryListDto> Items { get; set; }
    }
}
