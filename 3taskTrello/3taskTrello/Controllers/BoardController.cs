namespace 3taskTrello.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController :ControllerBase
    {
        private readonly ILogger<BoardController> _logger;

        public BoardController(ILogger<BoardController> logger)
        {
            this._logger = logger;
        }
    }
}