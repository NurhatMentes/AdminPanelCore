using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Dtos
{
    public class CreatedCategoryDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? EmendatorAdminId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public bool State { get; set; }
    }
}
