using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ContactRepository : EfRepositoryBase<Contact, BaseDbContext>, IContactRepository
{
    public ContactRepository(BaseDbContext context) : base(context)
    {
    }
}