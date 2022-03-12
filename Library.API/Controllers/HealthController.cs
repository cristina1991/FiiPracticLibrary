using Library.API.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.API.Controllers
{
    [Route(RouteConstants.RouteHealth)]
    public class HealthController : Controller
    {

        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(); 
        }

        [HttpPost]
        public IActionResult Add()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }
    }
}
