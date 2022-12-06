using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class UserLogRepository : EfRepositoryBase<UserLog, BaseDbContext>, IUserLogRepository
{
    public UserLogRepository(BaseDbContext context) : base(context)
    {
    }
}