using System.ComponentModel.DataAnnotations;
using Sorter.Core.Domain;

namespace Sorter.Api.Model
{
    public class SortDto
    {
        [Required]
        public IList<long> Numbers { get; set; }

        /// <summary>
        /// defaults to bubble sort when algorithm is not provided by a client
        /// </summary>
        public SortAlgorithm SortAlgorithm { get; set; } = SortAlgorithm.BubbleSort;
    }
}
