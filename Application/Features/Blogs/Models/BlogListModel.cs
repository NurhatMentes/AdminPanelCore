using Application.Features.Products.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Blogs.Dtos;

namespace Application.Features.Blogs.Models
{
    public class BlogListModel : BasePageableModel
    {
        public IList<BlogListDto> Items { get; set; }
    }
}
