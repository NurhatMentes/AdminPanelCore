using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Slider.Dtos
{
    public class SliderListDto
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> EmendatorAdminId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public bool State { get; set; }
    }
}
