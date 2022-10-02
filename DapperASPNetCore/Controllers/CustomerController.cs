using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperASPNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get() => new string[] { "John Doe", "Jane Doe" };
    }
}
