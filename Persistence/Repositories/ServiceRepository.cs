using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ServiceRepository : EfRepositoryBase<Service, BaseDbContext>, IServiceRepository
{
    public ServiceRepository(BaseDbContext context) : base(context)
    {
    }
}