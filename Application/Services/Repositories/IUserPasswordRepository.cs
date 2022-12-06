using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IUserPasswordRepository : IAsyncRepository<UserPassword>, IRepository<UserPassword>
{
}