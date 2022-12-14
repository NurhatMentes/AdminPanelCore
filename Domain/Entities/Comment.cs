using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Comment : Entity
{
    public int? BlogId { get; set; }
    public int? ProductId { get; set; }
    public string FirstLastName { get; set; }
    public string Email { get; set; }
    public string CommentContent { get; set; }
    public bool Confirmation { get; set; }
    public DateTime? Date { get; set; }

    public virtual Blog Blogs { get; set; }
    public virtual Product Products { get; set; }

    public Comment()
    {
    }
    public Comment(int? blogId, int? productId, string firstLastName, string email, string commentContent, bool confirmation, DateTime? date)
    {
        BlogId = blogId;
        ProductId = productId;
        FirstLastName = firstLastName;
        Email = email;
        CommentContent = commentContent;
        Confirmation = confirmation;
        Date = date;
    }

}