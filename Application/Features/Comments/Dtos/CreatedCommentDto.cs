namespace Application.Features.Comments.Dtos;

public class CreatedCommentDto
{
    public int CommentId { get; set; }
    public int? BlogId { get; set; }
    public int? ProductId { get; set; }
    public string FirstLastName { get; set; }
    public string Email { get; set; }
    public string CommentContent { get; set; }
}