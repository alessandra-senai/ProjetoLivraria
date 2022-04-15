using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Models;


namespace ProjetoLivraria.Controllers.V2
{
    [ApiController]
    [Route("api/autores")]
    [ApiVersion("2.0")]
    public class AutoresController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return new List<Autor>
                                    {
                                        new Autor
                                        {
                                            Id = 1,
                                            Ativo= true,
                                            DataNascimento = new DateTime(2019, 07,09),
                                            Nome = "João Pedro da Silva"
                                        }                                     
                                    };

        }
    }
}
