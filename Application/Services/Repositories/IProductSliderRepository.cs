using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IProductSliderRepository : IAsyncRepository<ProductSlider>, IRepository<ProductSlider>
{
}