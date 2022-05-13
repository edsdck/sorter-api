using Sorter.Core.Domain;
using Sorter.Core.Interfaces.Sorting;

namespace Sorter.Core.Services.Sorting
{
    public class SelectionSortStrategy : ISortStrategy
    {
        public SortAlgorithm SortAlgorithm => SortAlgorithm.SelectionSort;

        public List<long> Sort(IEnumerable<long> numbers)
        {
            var sorted = new List<long>(numbers);

            for (var i = 0; i < sorted.Count; i++)
            {
                var min = i;
                for (var j = i + 1; j < sorted.Count; j++)
                {
                    if (sorted[min] > sorted[j])
                    {
                        min = j;
                    }
                }

                if (min == i) continue;
                (sorted[min], sorted[i]) = (sorted[i], sorted[min]);
            }

            return sorted;
        }
    }
}
