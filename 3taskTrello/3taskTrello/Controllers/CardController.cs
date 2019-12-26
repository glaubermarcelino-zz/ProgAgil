namespace 3taskTrello.Controllers
{
     [ApiController]
    [Route("[controller]")]
    public class CardController :ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        public CardController(ILogger<CardController> logger)
        {
            this._logger = logger;
        }

        [HttpGet("{boardId}")]
        public Task<Board> GetBoardByid(int boardId){

        }

        
        [HttpGet)]
        public Task<Board> GetAllBoards(){
            
        }
    }
}