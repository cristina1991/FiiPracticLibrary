using Library.Data.Entities;
using Library.Data.Entities.Context;
using Library.Data.Implementations;
using Library.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.API.Extensions.ServiceCollection
{
    internal static class AddPersistenceLayerExtension
    {
        internal static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:LibraryConnection"]));

            //system tables
            services.AddTransient<IRepository<Book>, DefaultRepository<Book>>();
            services.AddTransient<IRepository<Borrower>, DefaultRepository<Borrower>>();
        }
    }
}

