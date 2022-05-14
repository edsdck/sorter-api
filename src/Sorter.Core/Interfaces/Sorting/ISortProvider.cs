using Sorter.Core.Domain;

namespace Sorter.Core.Interfaces.Sorting
{
    public interface ISortProvider
    {
        public ISortStrategy GetAlgorithm(SortAlgorithm sortAlgorithm);
    }
}
