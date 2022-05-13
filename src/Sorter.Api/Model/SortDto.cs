using Sorter.Core.Domain;

namespace Sorter.Api.Model
{
    public class SortDto
    {
        public IList<long> Numbers { get; set; }

        public SortAlgorithm SortAlgorithm { get; set; }
    }
}
