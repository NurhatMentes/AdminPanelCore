using Core.Persistence.Paging;
using Application.Features.Slider.Dtos;

namespace Application.Features.Slider.Models
{
    public class SliderListModel : BasePageableModel
    {
        public IList<SliderListDto> Items { get; set; }
    }
}
