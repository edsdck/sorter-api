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
        private readonly ISortContext _sortContext;

        public SortController(
            IFileHandler fileHandler,
            ISortContext sortContext)
        {
            _fileHandler = fileHandler;
            _sortContext = sortContext;
        }

        [HttpPost]
        public IActionResult Sort(SortDto dto)
        {
            var sorted = _sortContext.SortByAlgorithm(dto.Numbers, dto.SortAlgorithm);

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
