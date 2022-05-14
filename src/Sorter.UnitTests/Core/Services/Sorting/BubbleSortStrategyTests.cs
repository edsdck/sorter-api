using System.Collections.Generic;
using NUnit.Framework;
using Sorter.Core.Domain;
using Sorter.Core.Services.Sorting;

namespace Sorter.UnitTests.Core.Services.Sorting
{
    [TestFixture]
    public class BubbleSortStrategyTests
    {
        private BubbleSortStrategy _strategy;

        [SetUp]
        public void Setup()
        {
            _strategy = new BubbleSortStrategy();
        }

        [TestCaseSource(typeof(SortTestCases), nameof(SortTestCases.Basic))]
        public void Sort_NumberList_ReturnsCorrectlySorted(
            IEnumerable<long> unsorted,
            IEnumerable<long> expected)
        {
            var actual = _strategy.Sort(unsorted);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_StrategyReturnsCorrectSortType()
        {
            Assert.AreEqual(SortAlgorithm.BubbleSort, _strategy.SortAlgorithm);
        }
    }
}
