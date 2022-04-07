using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoLivraria.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/autores")]
    [ApiVersion("2.0")]
    public class AutoresController : ControllerBase
    {
        [MapToApiVersion("2.0")]
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return new List<Autor>();
        }



    }
}
