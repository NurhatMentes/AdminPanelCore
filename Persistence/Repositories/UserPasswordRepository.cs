using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class UserPasswordRepository : EfRepositoryBase<UserPassword, BaseDbContext>, IUserPasswordRepository
{
    public UserPasswordRepository(BaseDbContext context) : base(context)
    {
    }
}