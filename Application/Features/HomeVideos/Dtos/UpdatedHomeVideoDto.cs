namespace Application.Features.HomeVideos.Dtos
{
    public class UpdatedHomeVideoDto
    {
        public int HomeVideoId { get; set; }
        public int EmendatorAdminId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
    }
}
