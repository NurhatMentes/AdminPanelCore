using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ProductSliderRepository : EfRepositoryBase<ProductSlider, BaseDbContext>, IProductSliderRepository
{
    public ProductSliderRepository(BaseDbContext context) : base(context)
    {
    }
}