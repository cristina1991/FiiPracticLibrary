using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Library.API.Mappers;

namespace Library.API.ServiceCollection
{
    internal static class AddMappingExtensions
    {
        internal static void AddMapping(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BookProfile());
                cfg.AddProfile(new BorowerProfile());
            });

            services.AddTransient(cfg=> config.CreateMapper());
        }
    }
}
