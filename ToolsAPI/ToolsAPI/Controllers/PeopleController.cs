using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolsAPI.BusinessLayer.Services;

namespace ToolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService service;

        public PeopleController(IPeopleService service)
        {
            this.service = service;
        }

        [HttpGet("{filter}")]
        public async Task<IActionResult> FilterPeople(string filter)
        {
            var people = await service.GetListOfPeople(filter);
            return Ok(people);
        }
        
    }
}
