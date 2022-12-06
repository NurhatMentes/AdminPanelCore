using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class TablesLogRepository : EfRepositoryBase<TablesLog, BaseDbContext>, ITablesLogRepository
{
    public TablesLogRepository(BaseDbContext context) : base(context)
    {
    }
}