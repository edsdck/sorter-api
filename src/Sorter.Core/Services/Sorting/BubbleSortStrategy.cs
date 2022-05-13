using Sorter.Core.Domain;
using Sorter.Core.Interfaces.Sorting;

namespace Sorter.Core.Services.Sorting
{
    public class BubbleSortStrategy : ISortStrategy
    {
        public SortAlgorithm SortAlgorithm => SortAlgorithm.BubbleSort;

        public List<long> Sort(IEnumerable<long> numbers)
        {
            var sorted = new List<long>(numbers);
            var swapped = true;

            while (swapped)
            {
                swapped = false;
                for (var i = 1; i <= sorted.Count - 1; i++)
                {
                    if (sorted[i - 1] <= sorted[i]) continue;

                    (sorted[i - 1], sorted[i]) = (sorted[i], sorted[i - 1]);
                    swapped = true;
                }
            }

            return sorted;
        }
    }
}
