using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class SiteIdentityRepository : EfRepositoryBase<SiteIdentity, BaseDbContext>, ISiteIdentityRepository
{
    public SiteIdentityRepository(BaseDbContext context) : base(context)
    {
    }
}