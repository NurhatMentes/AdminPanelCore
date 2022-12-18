using System.Reflection;
using Core.Security.JWT;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Services.AuthService;
using Application.Auth.Rules;
using Application.Features.AboutUs.Rules;
using Application.Features.Blogs.Rules;
using Application.Features.Categories.Rules;
using Application.Features.Comments.Rules;
using Application.Features.Sliders.Rules;
using Application.Features.Userss.Rules;
using Application.Features.Contact.Rules;
using Application.Features.Products.Rules;
using Application.Features.ProductSliders.Rules;
using Application.Features.Services.Rules;
using Application.Features.SiteIdentity.Rules;
using Application.Features.SubCategories.Rules;
using Application.Features.TablesLogs.Rules;
using Application.Services.FileService;
using Application.Features.HomeVideos.Rules;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<BlogBusinessRules>();
            services.AddScoped<HomeVideoBusinessRules>();
            services.AddScoped<SliderBusinessRules>();
            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<CommentBusinessRules>();
            services.AddScoped<ProductSliderBusinessRules>();
            services.AddScoped<ContactBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<SubCategoryBusinessRules>();
            services.AddScoped<AboutUsBusinessRules>();
            services.AddScoped<SiteIdentityBusinessRules>();
            services.AddScoped<TablesLogBusinessRules>();
            services.AddScoped<ServiceBusinessRules>();

            services.AddTransient<IAuthService, AuthManager>();
            services.AddTransient<IFileService, FileManager>();
            services.AddTransient<ITokenHelper, JwtHelper>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
