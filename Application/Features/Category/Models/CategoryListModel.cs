using Application.Features.Slider.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Category.Dtos;

namespace Application.Features.Category.Models
{
    public class CategoryListModel : BasePageableModel
    {
        public IList<CategoryListDto> Items { get; set; }
    }
}
