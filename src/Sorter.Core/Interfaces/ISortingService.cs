namespace Sorter.Core.Interfaces
{
    public interface ISortingService
    {
        IList<long> Sort(IList<long> numbers);
    }
}