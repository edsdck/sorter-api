using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sorter.Api;
using Sorter.Core.Interfaces.Sorting;
using Sorter.Core.Services.Sorting;

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

            serviceCollection.AddScoped<ISortContext, SortContext>();
            serviceCollection.AddScoped<ISortStrategy, BubbleSortStrategy>();
            serviceCollection.AddScoped<ISortStrategy, SelectionSortStrategy>();

            return serviceCollection;
        }
    }
}
