namespace Application.Features.HomeVideos.Dtos
{
    public class CreatedHomeVideoDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
    }
}
