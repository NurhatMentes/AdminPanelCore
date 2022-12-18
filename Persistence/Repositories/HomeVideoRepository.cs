using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class HomeVideoRepository : EfRepositoryBase<HomeVideo, BaseDbContext>, IHomeVideoRepository
    {
        public HomeVideoRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
