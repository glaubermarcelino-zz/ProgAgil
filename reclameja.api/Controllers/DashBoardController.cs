using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using reclameja.api.Models;

namespace reclameja.api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<DashboardItem> itens = new List<DashboardItem>()
            {
                new DashboardItem{Name="Janeiro",Series = new List<Serie>(){ new Serie{Label="Janeiro",Color="#e8e8e8",Value=-100,ValueLabel="100"},
                                                                                new Serie{Label="Janeiro",Color="#1cff",Value=100,ValueLabel="80"},
                                                                                new Serie{Label="Vendas",Color="#ccaaff",Value=100,ValueLabel="30"}
                                                                            },Type = EChartType.BarChart},
                new DashboardItem{Name="Fevereiro",Series = new List<Serie>(){  new Serie{Label="Janeiro",Color="#1cff",Value=100,ValueLabel="80"},
                                                                                new Serie{Label="Vendas",Color="#ccaaff",Value=100,ValueLabel="30"}
                                                                                },Type = EChartType.LineChart},
                new DashboardItem{Name="Março",Series = new List<Serie>(){                                                                
                                                                                new Serie{Label="Estornos",Color="#994887",Value=10,ValueLabel="80"},
                                                                                new Serie{Label="Baixas",Color="#ccaaff",Value=50,ValueLabel="30"},
                                                                                new Serie{Label="Entradas",Color="#31479e",Value=10,ValueLabel="30"},
                                                                                new Serie{Label="Saidas",Color="#ab3a15",Value=20,ValueLabel="5"},
                                                                                new Serie{Label="Estornos",Color="#ab500a",Value=40,ValueLabel="5"},
                                                                                new Serie{Label="Doações",Color="#e63939",Value=0,ValueLabel="30"}},Type = EChartType.RadarChart}
                                                                                ,
                new DashboardItem{Name="Almoxarifado",Series = new List<Serie>(){                                                                
                                                                                new Serie{Label="Cancelamento",Color="#21962b",Value=30,ValueLabel="800"},
                                                                                new Serie{Label="Entradas",Color="#31479e",Value=10,ValueLabel="30"},
                                                                                new Serie{Label="Saidas",Color="#ab3a15",Value=20,ValueLabel="5"},
                                                                                new Serie{Label="Estornos",Color="#ab500a",Value=40,ValueLabel="5"},
                                                                                new Serie{Label="Doações",Color="#e63939",Value=0,ValueLabel="30"}
                                                                            },Type = EChartType.RadialGaugeChart}
            };
            return Ok(itens);
        }
    }
}