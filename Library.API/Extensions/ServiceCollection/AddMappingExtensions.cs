using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using service = Library.BLL.Mapper;
using api = Library.API.Mappers;

namespace Library.API.Extensions.ServiceCollection
{
    internal static class AddMappingExtensions
    {
        internal static void AddMapping(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new api.BookProfile());
                cfg.AddProfile(new api.BorrowerProfile());
                cfg.AddProfile(new service.BookProfile());
                cfg.AddProfile(new service.BorrowerProfile());
            });

            services.AddTransient(c => config.CreateMapper());
        }
    }
}
