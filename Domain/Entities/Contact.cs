using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Contact : Entity
{
    public int? UserId { get; set; }
    public int? EmendatorAdminId { get; set; }
    public string Adress { get; set; }
    public string Tel { get; set; }
    public string Email { get; set; }
    public string EmailPassword { get; set; }
    public string Whatsapp { get; set; }
    public string Facebook { get; set; }
    public string Twitter { get; set; }
    public string Instagram { get; set; }

    public Contact()
    {
    }
    public Contact(int id, int? emendatorAdminId, string adress, string tel, string email, string emailPassword, string whatsapp, string facebook, string twitter, string instagram, int? userId) : base(id)
    {
        Id = id;

        EmendatorAdminId = emendatorAdminId;
        Adress = adress;
        Tel = tel;
        Email = email;
        EmailPassword = emailPassword;
        Whatsapp = whatsapp;
        Facebook = facebook;
        Twitter = twitter;
        Instagram = instagram;
        UserId = userId;
    }

    public virtual ExtendedUser User { get; set; }
}