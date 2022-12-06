using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class Contact : Entity
{
    public int ContactId { get; set; }
    public Nullable<int> EmendatorAdminId { get; set; }
    public string Adress { get; set; }
    public string Tel { get; set; }
    public string Email { get; set; }
    public string EmailPassword { get; set; }
    public string Whatsapp { get; set; }
    public string Facebook { get; set; }
    public string Twitter { get; set; }
    public string Instagram { get; set; }

    public virtual ExtendedUser Users { get; set; }
}