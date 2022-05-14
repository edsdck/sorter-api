using Microsoft.AspNetCore.Mvc;
using Sorter.Api.Model;
using Sorter.Core.Interfaces.Sorting;
using Sorter.Infrastructure;

namespace Sorter.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/sort")]
    [ApiController]
    public class SortController : ControllerBase
    {
        private readonly IFileHandler _fileHandler;
        private readonly ISortProvider _sortProvider;

        public SortController(
            IFileHandler fileHandler,
            ISortProvider sortContext)
        {
            _fileHandler = fileHandler;
            _sortProvider = sortContext;
        }

        [HttpPost]
        public IActionResult Sort(SortDto dto)
        {
            var sorter = _sortProvider.GetAlgorithm(dto.SortAlgorithm);
            var sorted = sorter.Sort(dto.Numbers);

            _fileHandler.Write(sorted);

            return Ok(sorted);
        }

        [HttpGet]
        public IActionResult GetSorted()
        {
            var result = _fileHandler.Read<IList<long>>();

            return Ok(result);
        }
    }
}
