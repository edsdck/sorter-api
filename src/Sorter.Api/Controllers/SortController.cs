using Microsoft.AspNetCore.Mvc;
using Sorter.Api.Model;
using Sorter.Core.Interfaces;

namespace Sorter.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/sort")]
    [ApiController]
    public class SortController : ControllerBase
    {
        private readonly ISortingService _sortingService;
        private readonly IFileHandler _fileHandler;

        public SortController(
            ISortingService sortingService,
            IFileHandler fileHandler)
        {
            _sortingService = sortingService;
            _fileHandler = fileHandler;
        }

        [HttpPost]
        public IActionResult Sort(SortDto dto)
        {
            var sorted = _sortingService.Sort(dto.Numbers);
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
