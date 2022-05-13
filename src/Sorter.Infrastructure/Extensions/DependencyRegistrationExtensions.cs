using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sorter.Api;
using Sorter.Core.Interfaces;
using Sorter.Core.Services;

namespace Sorter.Infrastructure.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection RegisterApp(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.Configure<FileHandlingOptions>(configuration.GetSection(FileHandlingOptions.FileHandling));

            serviceCollection.AddSingleton<IFileHandler, FileHandler>();
            serviceCollection.AddScoped<ISortingService, SortingService>();

            return serviceCollection;
        }
    }
}
