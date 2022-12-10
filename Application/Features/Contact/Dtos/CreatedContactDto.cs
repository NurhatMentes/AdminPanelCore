namespace Application.Features.Contact.Dtos
{
    public class CreatedContactDto
    {
        public int Id { get; set; }
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
    }
}
