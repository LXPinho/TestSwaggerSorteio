using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using System.Text.Json;
using TestSwaggerSorteio.Data;
using TestSwaggerSorteio.Models;

namespace TestSwaggerSorteio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteioController : ControllerBase
    {
        [HttpGet("{vibesAcumuladas}")]
        public ActionResult<string> ListarSorteior(int vibesAcumuladas = 0)
        {
            string result = string.Empty;
            bool firstTime = true;
            SorteioData sorteioData = SorteioData.getInstance();
            for( int i = (new Random()).Next(1, 6); i > 0 && vibesAcumuladas / 30 > 0; i--, firstTime = false, vibesAcumuladas -= 30)
                 SorteioData.AddSorteioData(firstTime, vibesAcumuladas);
            result = JsonSerializer.Serialize(sorteioData.getListSorteios()) ;
            return Ok(result);
        }

        [HttpPost("{vibesAcumuladas}")]
        public ActionResult<string> AdicionarSorteior(int vibesAcumuladas = 30)
        {
            string result = string.Empty;
            bool firstTime = true;
            if (vibesAcumuladas <= 0) vibesAcumuladas = 300;
            SorteioData sorteioData = SorteioData.getInstance();
            for (int i = (new Random()).Next(1, 6); i > 0 && vibesAcumuladas / 30 > 0; i--, firstTime = false, vibesAcumuladas -= 30)
                SorteioData.AddSorteioData(firstTime, vibesAcumuladas);
            List<Sorteios> listaSorteio = sorteioData.getListSorteios();
            result = JsonSerializer.Serialize(listaSorteio.Where(s => s.NumeroDoSorteio == listaSorteio.Count).ToList()) ;
            return Ok(result);
        }

        [HttpDelete("{numeroSorteio}")]        
        public ActionResult ClearAll(int numeroSorteio = 0)
        {
            return Ok(JsonSerializer.Serialize(SorteioData.getInstance().ClearAll(numeroSorteio)));
        }
        
    }
}
