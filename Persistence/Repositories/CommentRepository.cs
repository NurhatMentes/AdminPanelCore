using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class CommentRepository : EfRepositoryBase<Comment, BaseDbContext>, ICommentRepository
{
    public CommentRepository(BaseDbContext context) : base(context)
    {
    }
}