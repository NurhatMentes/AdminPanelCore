using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ISystemAdminRepository : IAsyncRepository<SystemAdmin>, IRepository<SystemAdmin>
{
}