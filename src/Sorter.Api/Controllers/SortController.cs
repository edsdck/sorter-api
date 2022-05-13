using Microsoft.AspNetCore.Mvc;
using Sorter.Api.Model;

namespace Sorter.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/sort")]
    [ApiController]
    public class SortController : ControllerBase
    {
        [HttpPost]
        public IActionResult Sort(SortDto dto)
        {
            var swapped = true;
            while (swapped)
            {
                swapped = false;
                for (var i = 1; i <= dto.Numbers.Count-1; i++)
                {
                    if (dto.Numbers[i-1] > dto.Numbers[i])
                    {
                        var temp = dto.Numbers[i];
                        dto.Numbers[i] = dto.Numbers[i-1];
                        dto.Numbers[i-1] = temp;
                        swapped = true;
                    }
                }
            }

            return Ok(dto.Numbers);
        }

        [HttpGet]
        public IActionResult GetSorted()
        {
            return Ok();
        }
    }
}
