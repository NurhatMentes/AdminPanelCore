using Core.Persistence.Paging;
using Application.Features.SubCategories.Dtos;

namespace Application.Features.SubCategories.Models
{
    public class SubCategoryListModel : BasePageableModel
    {
        public IList<SubCategoryListDto> Items { get; set; }
    }
}
