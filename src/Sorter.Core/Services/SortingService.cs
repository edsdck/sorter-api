using Sorter.Core.Interfaces;

namespace Sorter.Core.Services
{
    public class SortingService : ISortingService
    {
        public List<long> Sort(IList<long> numbers)
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

        public List<long> SelectionSort(IList<long> numbers)
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