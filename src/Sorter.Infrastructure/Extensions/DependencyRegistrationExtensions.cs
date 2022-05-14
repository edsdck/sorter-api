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
            serviceCollection.Configure<FileManagerOptions>(configuration.GetSection(FileManagerOptions.FileHandling));
            serviceCollection.AddSingleton<IFileManager, FileManager>();

            serviceCollection.AddScoped<ISortProvider, SortProvider>();
            serviceCollection.AddScoped<ISortStrategy, BubbleSortStrategy>();
            serviceCollection.AddScoped<ISortStrategy, SelectionSortStrategy>();

            return serviceCollection;
        }
    }
}
