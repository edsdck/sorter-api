using System.Collections.Generic;
using NUnit.Framework;

namespace Sorter.UnitTests.Core.Services.Sorting
{
    public static class SortTestCases
    {
        public static IEnumerable<TestCaseData> Basic
        {
            get
            {
                yield return new TestCaseData(new List<long> { 1, 0, -1 }, new List<long> { -1, 0, 1 });
                yield return new TestCaseData(new List<long> { 1, 2, 3 }, new List<long> { 1, 2, 3 });
                yield return new TestCaseData(new List<long> { 3, 2, 1 }, new List<long> { 1, 2, 3 });
                yield return new TestCaseData(new List<long> { 1, 0, 0 }, new List<long> { 0, 0, 1 });
                yield return new TestCaseData(new List<long> { 1 }, new List<long> { 1 });
                yield return new TestCaseData(new List<long> { }, new List<long> { });
                yield return new TestCaseData(
                    new List<long> { 3, 10, 5, 4, 2, 9, 1, 7, 8, 6 },
                    new List<long> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            }
        }
    }
}
