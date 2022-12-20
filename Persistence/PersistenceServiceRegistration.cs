using Application.Services.AuthService;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ControlPanelCoreDbConnectionString")));

            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IHomeVideoRepository, HomeVideoRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductSliderRepository, ProductSliderRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ISiteIdentityRepository, SiteIdentityRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ISystemAdminRepository, SystemAdminRepository>();
            services.AddScoped<ITablesLogRepository, TablesLogRepository>();
            services.AddScoped<IUserLogRepository, UserLogRepository>();
            services.AddScoped<IUserPasswordRepository, UserPasswordRepository>();


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

            return services;
        }
    }
}
