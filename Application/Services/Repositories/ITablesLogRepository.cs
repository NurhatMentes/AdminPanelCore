using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ITablesLogRepository : IAsyncRepository<TablesLog>, IRepository<TablesLog>
{
}