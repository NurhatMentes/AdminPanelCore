using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IHomeVideoRepository : IAsyncRepository<HomeVideo>, IRepository<HomeVideo>
{
}