using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriandoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CriandoAPI.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class FundoCapitalController :Controller
    {
        List<FundoCapital> listaFundoCapital = new List<FundoCapital>(){
                new FundoCapital{
                    Nome = "Viagem ao Canadá",
                    ValorAtual=1.500,
                    ValorNecessario=10.000,
                    DataResgate= new System.DateTime(2020,11,01)
                },
                new FundoCapital{
                    Nome = "Férias em Gramado",
                    ValorAtual=0.0,
                    ValorNecessario=5.000,
                    DataResgate= new System.DateTime(2020,04,30)
                }
            };

        [HttpGet("v1/fundocapital")]
        public IActionResult ListarFundos()
        {
            return Ok(listaFundoCapital);
        }

        [HttpGet("v1/fundocapital/{idFundo}")]
        public IActionResult BuscarFundoPorId(Guid idFundo)
        {
            var FundoCapital = listaFundoCapital
                                .Where(f => f.Id == idFundo);
            return Ok(FundoCapital);
        }

        [HttpPost("v1/fundocapital/{FundoCapital}")]
        public IActionResult NovoFundoCaptial(FundoCapital fundoCapital)
        {
            return Ok();
        }
        
        [HttpPut("v1/fundocapital/{IdFundo}")]
        public IActionResult AtualiarFundo(Guid idFundo,[FromBody]FundoCapital fundoCapital)
        {
            var fundo = listaFundoCapital
                                .Where(f => f.Id == idFundo);
            if(fundo==null)NotFound();

            return Ok(fundo);
        }

        [HttpDelete("v1/fundocapital/{IdFundo}")]
        public IActionResult DeletarFundo(Guid idFundo,[FromBody]FundoCapital fundoCapital)
        {
            var fundo = listaFundoCapital
                                .Where(f => f.Id == idFundo);
            if(fundo==null)NotFound();

            return Ok(fundo);
        }
    }
}