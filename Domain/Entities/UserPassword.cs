using Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserPassword : Entity
{
    public int UserId { get; set; }
    public string Password { get; set; }
    public string CurrentPassword { get; set; }

}