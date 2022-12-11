namespace Application.Features.Slider.Dtos
{
    public class CreatedSliderDto
    {
        public int SliderId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
    }
}
