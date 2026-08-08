using Microsoft.AspNetCore.Mvc;

namespace ketoan.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "Success", message = "API ketoan.Server dang ho?t d?ng t?t!" });
        }
    }
}
