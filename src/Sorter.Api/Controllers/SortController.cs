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

        public SortController(ISortingService sortingService)
        {
            _sortingService = sortingService;
        }

        [HttpPost]
        public IActionResult Sort(SortDto dto)
        {
            var sorted = _sortingService.Sort(dto.Numbers);

            return Ok(sorted);
        }

        [HttpGet]
        public IActionResult GetSorted()
        {
            return Ok();
        }
    }
}
