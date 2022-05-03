using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DockerDemo.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("calculator")]
        public int Calculator(int x, int y)
        {
            Log.Information($"Result = {x} + {y} = {x + y}");

            return x + y;
        }
    }
}
