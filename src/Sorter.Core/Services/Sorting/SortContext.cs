using Sorter.Core.Domain;
using Sorter.Core.Interfaces.Sorting;

namespace Sorter.Core.Services.Sorting
{
    public class SortContext : ISortContext
    {
        private readonly IEnumerable<ISortStrategy> _strategies;

        public SortContext(IEnumerable<ISortStrategy> strategies)
        {
            _strategies = strategies;
        }

        public List<long> SortByAlgorithm(IEnumerable<long> numbers, SortAlgorithm sortAlgorithm)
        {
            return _strategies.Single(strat => strat.SortAlgorithm == sortAlgorithm).Sort(numbers);
        }
    }
}
