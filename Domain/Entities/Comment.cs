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

    public virtual Blogs Blogs { get; set; }
    public virtual Product Products { get; set; }
}