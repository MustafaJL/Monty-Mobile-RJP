using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monty_Mobile_RJP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            this.logger.LogError("Error");
            return Ok("hello");
        }
    }
}
