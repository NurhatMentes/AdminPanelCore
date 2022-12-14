namespace Application.Features.Sliders.Dtos
{
    public class UpdatedSliderDto
    {
        public int SliderId { get; set; }
        public int UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}
