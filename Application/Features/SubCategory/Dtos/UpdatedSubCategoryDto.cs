namespace Application.Features.SubCategory.Dtos
{
    public class UpdatedSubCategoryDto
    {
        public int SubCategoryId { get; set; }
        public int? UserId { get; set; }
        public int? EmendatorAdminId { get; set; }
        public int? CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string ImgUrl { get; set; }
        public bool State { get; set; }
    }
}
