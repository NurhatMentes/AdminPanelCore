namespace Application.Features.Comments.Dtos
{
    public class CommentListDto
    {
        public int CommentId { get; set; }
        public string BlogName { get; set; }
        public string ProductName { get; set; }
        public string FirstLastName { get; set; }
        public string Email { get; set; }
        public string CommentContent { get; set; }
        public bool Confirmation { get; set; }
    }
}
