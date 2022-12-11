namespace Application.Features.Category.Dtos
{
    public class CreatedCategoryDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public bool State { get; set; }
    }
}
