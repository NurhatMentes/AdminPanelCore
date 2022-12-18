using Application.Features.Comments.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Comments.Models
{
    public class CommentListModel : BasePageableModel
    {
        public IList<CommentListDto> Items { get; set; }
    }
}


