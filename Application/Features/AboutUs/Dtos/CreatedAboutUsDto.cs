namespace Application.Features.AboutUs.Dtos
{
    public class CreatedAboutUsDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? EmendatorAdminId { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}
