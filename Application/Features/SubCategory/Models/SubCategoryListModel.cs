using Core.Persistence.Paging;
using Application.Features.SubCategory.Dtos;

namespace Application.Features.SubCategory.Models
{
    public class SubCategoryListModel : BasePageableModel
    {
        public IList<SubCategoryListDto> Items { get; set; }
    }
}
