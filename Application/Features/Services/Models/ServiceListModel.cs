using Core.Persistence.Paging;
using Application.Features.Services.Dtos;

namespace Application.Features.Services.Models
{
    public class ServiceListModel : BasePageableModel
    {
        public IList<ServiceListDto> Items { get; set; }
    }
}
