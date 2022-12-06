using Core.Persistence.Repositories;

namespace Domain.Entities;

public partial class Comment : Entity
{
    public int CommentId { get; set; }
    public Nullable<int> BlogId { get; set; }
    public Nullable<int> ProductId { get; set; }
    public string FirstLastName { get; set; }
    public string Email { get; set; }
    public string CommentContent { get; set; }
    public bool Confirmation { get; set; }
    public Nullable<System.DateTime> Date { get; set; }

    public virtual Blogs Blogs { get; set; }
    public virtual Product Products { get; set; }
}