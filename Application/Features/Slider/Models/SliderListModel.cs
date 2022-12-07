using Application.Features.User.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Slider.Dtos;

namespace Application.Features.Slider.Models
{
    public class SliderListModel : BasePageableModel
    {
        public IList<SliderListDto> Items { get; set; }
    }
}
