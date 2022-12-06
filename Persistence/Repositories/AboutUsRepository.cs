using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AboutUsRepository : EfRepositoryBase<AboutUs, BaseDbContext>, IAboutUsRepository
    {
        public AboutUsRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
