namespace Application.Features.Blogs.Dtos;

public class BlogListDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string EmendatorAdminName { get; set; }
    public string? SubCategoryName { get; set; }
    public string CategoryName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImgUrl { get; set; }
    public bool State { get; set; }

}