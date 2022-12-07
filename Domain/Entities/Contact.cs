using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Contact : Entity
{
    public int? EmendatorAdminId { get; set; }
    public string Adress { get; set; }
    public string Tel { get; set; }
    public string Email { get; set; }
    public string EmailPassword { get; set; }
    public string Whatsapp { get; set; }
    public string Facebook { get; set; }
    public string Twitter { get; set; }
    public string Instagram { get; set; }

    public virtual ExtendedUser User { get; set; }
}