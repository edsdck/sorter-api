using NUnit.Framework;
using Sorter.Core.Domain;
using Sorter.Core.Services.Sorting;

namespace Sorter.UnitTests.Core.Services.Sorting
{
    [TestFixture]
    public class BubbleSortStrategyTests : BaseSortStrategyTests<BubbleSortStrategy>
    {
        public BubbleSortStrategyTests() : base(SortAlgorithm.BubbleSort)
        {
        }
    }
}
