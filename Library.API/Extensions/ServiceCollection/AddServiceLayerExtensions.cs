using Library.BLL.Implementations;
using Library.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Library.API.Extensions.ServiceCollection
{
    internal static class AddServiceLayerExtensions
    {
        internal static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBorrowerService, BorrowerService>();
        }
    }
}
