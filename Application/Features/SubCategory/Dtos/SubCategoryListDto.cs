namespace Application.Features.SubCategory.Dtos
{
    public class SubCategoryListDto
    {
        public int SubCategoryId { get; set; }
        public int UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }
        public bool State { get; set; }
    }
}
