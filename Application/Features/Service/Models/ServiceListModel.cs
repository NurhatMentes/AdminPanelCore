using Core.Persistence.Paging;
using Application.Features.Service.Dtos;

namespace Application.Features.Service.Models
{
    public class ServiceListModel : BasePageableModel
    {
        public IList<ServiceListDto> Items { get; set; }
    }
}
