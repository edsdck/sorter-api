using Sorter.Core.Domain;

namespace Sorter.Core.Interfaces.Sorting
{
    public interface ISortStrategy
    {
        SortAlgorithm SortAlgorithm { get; }

        List<long> Sort(IEnumerable<long> numbers);
    }
}
