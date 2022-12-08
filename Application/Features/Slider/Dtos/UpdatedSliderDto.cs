using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Slider.Dtos
{
    public class UpdatedSliderDto
    {
        public int SliderId { get; set; }
        public int UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}
