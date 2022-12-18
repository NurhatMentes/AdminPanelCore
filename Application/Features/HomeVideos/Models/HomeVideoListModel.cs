using Application.Features.HomeVideos.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.HomeVideo.Models
{
    public class HomeVideoListModel:BasePageableModel
    {
        public IList<HomeVideoListDto> Items { get; set; }
    }
}
