using Sorter.Core.Interfaces;

namespace Sorter.Core.Services
{
    public class SortingService : ISortingService
    {
        public IList<long> Sort(IList<long> numbers)
        {
            var sorted = new List<long>(numbers);

            var swapped = true;
            while (swapped)
            {
                swapped = false;
                for (var i = 1; i <= sorted.Count - 1; i++)
                {
                    if (sorted[i - 1] > sorted[i])
                    {
                        var temp = sorted[i];
                        sorted[i] = sorted[i - 1];
                        sorted[i - 1] = temp;

                        swapped = true;
                    }
                }
            }

            return sorted;
        }
    }
}