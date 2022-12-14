namespace Application.Features.Blogs.Dtos
{
    public class CreatedBlogDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Keywords { get; set; }
        public string ImgUrl { get; set; }
        public bool State { get; set; }

    }
}
