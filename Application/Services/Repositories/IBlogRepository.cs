using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IBlogRepository : IAsyncRepository<Blogs>, IRepository<Blogs>
{
}