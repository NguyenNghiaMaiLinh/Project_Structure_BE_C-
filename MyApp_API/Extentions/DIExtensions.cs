using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.AutoMapper;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Repository.Repository;
using MyApp.Service.Service;
using MyApp_API.Handler;

namespace MyApp_API.Extentions
{
    public static class DIExtensions
    {
        public static IServiceCollection AddDI(this IServiceCollection services)
        {
            AddServiceDI(services);
            AddRepoistoryDI(services);
            //add for data
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //SignalR
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #region automapper
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion
            return services;
        }

        public static void AddServiceDI(IServiceCollection services)
        {
         
            services.AddTransient<IRegisterService, RegisterService>();
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IFollowerService, FollowerService>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddTransient<IStepService, StepService>();
        }

        public static void AddRepoistoryDI(IServiceCollection services)
        {

            services.AddTransient<IRegisterRepository, RegisterRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IFollowerRepository, FollowerRepository>();
            services.AddTransient<IMaterialRepository, MaterialRepository>();
            services.AddTransient<IStepRepository, StepRepository>();
            services.AddTransient<IImageWriter, ImageWriter>();
            services.AddTransient<IImageHandler, ImageHandler>();
        }

    }
}
