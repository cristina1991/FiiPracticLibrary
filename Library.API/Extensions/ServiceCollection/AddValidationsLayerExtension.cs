using Library.BLL.Implementations;
using Library.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Library.API.Extensions.ServiceCollection
{
    internal static class AddValidationsLayerExtension
    {
        internal static void AddValidationsLayer(this IServiceCollection services)
        {
            services.AddTransient<IBookValidations, BookValidations>();
            services.AddTransient<IBorrowerValidations, BorrowerValidations>();
        }
    }
}
