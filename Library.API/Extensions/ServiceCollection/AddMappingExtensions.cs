using AutoMapper;
using Library.API.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Library.API.Extensions.ServiceCollection
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

            services.AddTransient(c => config.CreateMapper());
        }
    }
}
