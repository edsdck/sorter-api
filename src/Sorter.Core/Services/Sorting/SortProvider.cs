using Sorter.Core.Domain;
using Sorter.Core.Interfaces.Sorting;

namespace Sorter.Core.Services.Sorting
{
    public class SortProvider : ISortProvider
    {
        private readonly IEnumerable<ISortStrategy> _strategies;

        public SortProvider(IEnumerable<ISortStrategy> strategies)
        {
            _strategies = strategies;
        }

        public ISortStrategy GetAlgorithm(SortAlgorithm sortAlgorithm)
        {
            var strategy = _strategies
                .SingleOrDefault(strategy => strategy.SortAlgorithm == sortAlgorithm);

            if (strategy is null)
            {
                throw new NotImplementedException("Requested sort algorithm is not implemented.");
            }

            return strategy;
        }
    }
}
