namespace Application.Features.SiteIdentity.Dtos
{
    public class CreatedSiteIdentityDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
    }
}
