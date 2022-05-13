namespace Sorter.Core.Interfaces
{
    public interface ISortingService
    {
        List<long> SelectionSort(IList<long> numbers);

        List<long> Sort(IList<long> numbers);
    }
}