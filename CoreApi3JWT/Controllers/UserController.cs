namespace CoreApi3JWT.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class UserController : BaseControler
    {
        [HttpGet("/all")]
        public Task<IActionResult> GetAll()
        {

            return OK();
        }
    }
}