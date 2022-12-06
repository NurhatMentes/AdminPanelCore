using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ISliderRepository : IAsyncRepository<Slider>, IRepository<Slider>
{
}