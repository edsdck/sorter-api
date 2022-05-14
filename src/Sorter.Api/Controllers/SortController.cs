using Microsoft.AspNetCore.Mvc;
using Sorter.Api.Model;
using Sorter.Core.Interfaces.Sorting;
using Sorter.Shared.Interfaces;

namespace Sorter.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/sort")]
    [ApiController]
    [Produces("application/json")]
    public class SortController : ControllerBase
    {
        private readonly IFileManager _fileManager;
        private readonly ISortProvider _sortProvider;

        public SortController(
            IFileManager fileHandler,
            ISortProvider sortContext)
        {
            _fileManager = fileHandler;
            _sortProvider = sortContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Sort(SortDto dto)
        {
            var sorter = _sortProvider.GetAlgorithm(dto.SortAlgorithm);
            var sorted = sorter.Sort(dto.Numbers);

            _fileManager.Write(sorted);

            return CreatedAtAction(nameof(GetSorted), null);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<long>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IList<long> GetSorted()
        {
            var result = _fileManager.Read<IList<long>>();

            return result;
        }
    }
}
