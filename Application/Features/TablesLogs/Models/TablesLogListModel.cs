using Core.Persistence.Paging;
using Application.Features.TablesLogs.Dtos;

namespace Application.Features.TablesLogs.Models
{
    public class TablesLogListModel : BasePageableModel
    {
        public IList<TablesLogListDto> Items { get; set; }
    }
}
