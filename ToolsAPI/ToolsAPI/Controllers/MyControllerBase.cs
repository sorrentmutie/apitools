using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ToolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class MyControllerBase: ControllerBase
    {
    }
}
