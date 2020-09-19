using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchWebApi.DB;
using SearchWebApi.Interfaces;
using SearchWebApi.Models;

namespace SearchWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchProvider _searchProvider;

        public SearchController(ILogger<SearchController> logger, ISearchProvider searchProvider)
        {
            _logger = logger;
            _searchProvider = searchProvider;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<SearchDataModel>>> PostSearchData([FromBody] SearchModel searchModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            var result = await _searchProvider.SearchAsync(searchModel.SearchPhrase);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Welcome to Search api");
        }
    }
}
