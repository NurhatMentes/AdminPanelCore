using Core.Persistence.Paging;
using Application.Features.Blogs.Dtos;

namespace Application.Features.Blogs.Models
{
    public class BlogListModel : BasePageableModel
    {
        public IList<BlogListDto> Items { get; set; }
    }
}
