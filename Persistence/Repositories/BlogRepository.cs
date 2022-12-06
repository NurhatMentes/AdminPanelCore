using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class BlogRepository : EfRepositoryBase<Blogs, BaseDbContext>, IBlogRepository
{
    public BlogRepository(BaseDbContext context) : base(context)
    {
    }
}