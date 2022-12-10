using Application.Features.Contact.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Contact.Models
{
    public class ContactListModel: BasePageableModel
    {
        public IList<ContactListDto> Items { get; set; }
    }
}
