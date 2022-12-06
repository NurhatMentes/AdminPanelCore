using Core.Persistence.Repositories;

namespace Domain.Entities;

public partial class SystemAdmin : Entity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}