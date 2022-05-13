using Sorter.Core.Domain;

namespace Sorter.Core.Interfaces.Sorting
{
    public interface ISortContext
    {
        List<long> SortByAlgorithm(IEnumerable<long> numbers, SortAlgorithm sortAlgorithm);
    }
}
