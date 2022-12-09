using Application.Features.User.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.User.Models
{
    public class UserListModel:BasePageableModel
    {
        public IList<UserListDto> Items { get; set; }
    }
}
