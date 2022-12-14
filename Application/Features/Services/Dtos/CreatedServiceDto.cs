
namespace Application.Features.Services.Dtos
{
    public class CreatedServiceDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? EmendatorAdminId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string ImgUrl { get; set; }
        public bool State { get; set; }
    }
}
