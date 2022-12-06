using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ISiteIdentityRepository : IAsyncRepository<SiteIdentity>, IRepository<SiteIdentity>
{
}