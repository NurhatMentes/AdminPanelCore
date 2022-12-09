using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SiteIdentity.Dtos
{
    public class UpdatedSiteIdentityDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? EmendatorAdminId { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public bool? State { get; set; }
    }
}
