using System;
using Moq;
using NUnit.Framework;
using Sorter.Core.Domain;
using Sorter.Core.Interfaces.Sorting;
using Sorter.Core.Services.Sorting;

namespace Sorter.UnitTests.Core.Services.Sorting
{
    [TestFixture]
    public class SortProviderTests
    {
        private const SortAlgorithm SortAlgorithmTest = SortAlgorithm.SelectionSort;

        private Mock<ISortStrategy> _strategyMock1;
        private Mock<ISortStrategy> _strategyMock2;
        private ISortProvider _sortProvider;

        [SetUp]
        public void Setup()
        {
            _strategyMock1 = new Mock<ISortStrategy>();
            _strategyMock2 = new Mock<ISortStrategy>();

            _sortProvider = new SortProvider(new[] { _strategyMock1.Object, _strategyMock2.Object });
        }

        [TestCase(SortAlgorithm.SelectionSort)]
        [TestCase(SortAlgorithm.BubbleSort)]
        public void GetAlgorithm_ImplementedSortType_ReturnsStrategy(SortAlgorithm expected)
        {
            _strategyMock1.Setup(mock => mock.SortAlgorithm).Returns(SortAlgorithm.BubbleSort);
            _strategyMock2.Setup(mock => mock.SortAlgorithm).Returns(SortAlgorithm.SelectionSort);

            var result = _sortProvider.GetAlgorithm(expected);

            Assert.AreEqual(expected, result.SortAlgorithm);
        }

        [Test]
        public void GetAlgorithm_NotImplementedSortType_ThrowsException()
        {
            Assert.Throws<NotImplementedException>(() => _sortProvider.GetAlgorithm(SortAlgorithmTest));
        }

        [Test]
        public void GetAlgorithm_MoreThanOneSameStrategy_ThrowsException()
        {
            _strategyMock1.Setup(mock => mock.SortAlgorithm).Returns(SortAlgorithmTest);
            _strategyMock2.Setup(mock => mock.SortAlgorithm).Returns(SortAlgorithmTest);

            Assert.Throws<InvalidOperationException>(() => _sortProvider.GetAlgorithm(SortAlgorithmTest));
        }
    }
}
