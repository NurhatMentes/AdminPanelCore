using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class AboutUsRepository : EfRepositoryBase<AboutUs, BaseDbContext>, IAboutUsRepository
    {
        public AboutUsRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
