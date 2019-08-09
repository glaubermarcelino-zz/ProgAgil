using Microsoft.AspNetCore.Mvc;
using ProgAgil.Repository;

namespace ProgAgil.Domain.Controlers{

[Route("api/[controller]")]
[ApiController]
    public class PalestranteController :ControllerBase
    {
        private readonly IProAgilRepository _repo;

        public PalestranteController(IProAgilRepository repo)
        {
            _repo = repo;
        }

    }
}