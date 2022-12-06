using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IServiceRepository : IAsyncRepository<Domain.Entities.Service>, IRepository<Domain.Entities.Service>
{
}