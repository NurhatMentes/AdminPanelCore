using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class SliderRepository : EfRepositoryBase<Slider, BaseDbContext>, ISliderRepository
{
    public SliderRepository(BaseDbContext context) : base(context)
    {
    }
}