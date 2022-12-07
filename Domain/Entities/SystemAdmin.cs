using Core.Persistence.Repositories;

namespace Domain.Entities;

public class SystemAdmin : Entity
{
    public string Email { get; set; }
    public string Password { get; set; }
}