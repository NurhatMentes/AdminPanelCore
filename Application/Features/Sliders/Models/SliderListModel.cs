using Core.Persistence.Paging;
using Application.Features.Sliders.Dtos;

namespace Application.Features.Sliders.Models
{
    public class SliderListModel : BasePageableModel
    {
        public IList<SliderListDto> Items { get; set; }
    }
}
