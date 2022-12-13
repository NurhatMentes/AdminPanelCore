using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductSlider.Dtos
{
    public class CreatedProductSliderDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImgUrl { get; set; }
        public bool State { get; set; }
    }
}
