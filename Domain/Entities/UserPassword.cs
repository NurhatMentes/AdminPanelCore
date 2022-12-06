using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class UserPassword : Entity
{
    public int UserPasswordId { get; set; }
    public int UserId { get; set; }
    public string Password { get; set; }
    public string CurrentPassword { get; set; }

}