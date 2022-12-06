using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public partial class AboutUs:Entity
    {
        public int AboutUsId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> EmendatorAdminId { get; set; }
        public string Description { get; set; }
        public Nullable<bool> State { get; set; }

        public virtual ExtendedUser Users { get; set; }
    }
}
