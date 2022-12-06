using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class SystemAdminRepository : EfRepositoryBase<SystemAdmin, BaseDbContext>, ISystemAdminRepository
{
    public SystemAdminRepository(BaseDbContext context) : base(context)
    {
    }
}