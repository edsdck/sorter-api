using System.Collections.Generic;
using NUnit.Framework;
using Sorter.Core.Domain;
using Sorter.Core.Interfaces.Sorting;

namespace Sorter.UnitTests.Core.Services.Sorting
{
    public abstract class BaseSortStrategyTest<T> where T : ISortStrategy, new()
    {
        private T _strategyUnderTest;

        private readonly SortAlgorithm CorrectSortAlgorithm;

        public BaseSortStrategyTest(SortAlgorithm correctSortAlgorithm)
        {
            CorrectSortAlgorithm = correctSortAlgorithm;
        }

        [SetUp]
        public void Setup()
        {
            _strategyUnderTest = new T();
        }

        [TestCaseSource(typeof(SortTestCases), nameof(SortTestCases.Basic))]
        public void Sort_NumberList_ReturnsCorrectlySorted(
            IEnumerable<long> unsorted,
            IEnumerable<long> expected)
        {
            var actual = _strategyUnderTest.Sort(unsorted);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_StrategyReturnsCorrectSortType()
        {
            Assert.AreEqual(CorrectSortAlgorithm, _strategyUnderTest.SortAlgorithm);
        }
    }
}
