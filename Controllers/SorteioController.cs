using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using TestSwaggerSorteio.Data;
using TestSwaggerSorteio.Models;

namespace TestSwaggerSorteio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Sorteios>> ListarSorteior(int vibesAcumuladas = 0)
        {
            bool firstTime = true;
            SorteioData sorteioData = SorteioData.getInstance();
            for( int i = (new Random()).Next(1, 6); i > 0 && vibesAcumuladas / 30 > 1; i--, firstTime = false, vibesAcumuladas -= 30)
                 SorteioData.AddSorteioData(firstTime, vibesAcumuladas);
            return Ok(sorteioData.getListSorteios());
        }
    }
}
