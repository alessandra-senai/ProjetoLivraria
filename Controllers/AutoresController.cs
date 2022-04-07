using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Controllers
{
    [ApiController]
    [Route("api/autores")]
    [ApiVersion("1.0", Deprecated = true)]
    public class AutoresController : ControllerBase
    {
        [MapToApiVersion("1.0")]
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
                                        },
                                        new Autor
                                        {
                                            Id = 2,
                                            Ativo= true,
                                            DataNascimento = new DateTime(2019, 07,09),
                                            Nome = "João Pedro da Silva"
                                        }
                                    };

        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public Autor Get(int id)
        {
            var autores = new List<Autor>
                                    {
                                        new Autor
                                        {
                                            Id = 1,
                                            Ativo= true,
                                            DataNascimento = new DateTime(2019, 07,09),
                                            Nome = "João Pedro da Silva"
                                        },
                                        new Autor
                                        {
                                            Id = 2,
                                            Ativo= true,
                                            DataNascimento = new DateTime(2019, 07,09),
                                            Nome = "João Pedro da Silva"
                                        }
                                    };
            // LINQ = utilizado na manipulação de lista de objetos, dicionários e coleções
            // trabalha utilizando expressões LAMBDA

            return  autores.FirstOrDefault(x => x.Id == id);


           
        }

        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public void Post([FromBody] Autor autor)
        {
            var autores = new List<Autor>
                                    {
                                        new Autor
                                        {
                                            Id = 1,
                                            Ativo= true,
                                            DataNascimento = new DateTime(2019, 07,09),
                                            Nome = "João Pedro da Silva"
                                        },
                                        new Autor
                                        {
                                            Id = 2,
                                            Ativo= true,
                                            DataNascimento = new DateTime(2019, 07,09),
                                            Nome = "João Pedro da Silva"
                                        }
                                    };

            autores.Add(autor); 
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public Autor Put(int id, [FromBody] Autor autor)
        {
            var autores = new List<Autor>
                                    {
                                        new Autor
                                        {
                                            Id = 1,
                                            Ativo= true,
                                            DataNascimento = new DateTime(2019, 07,09),
                                            Nome = "João Pedro da Silva"
                                        },
                                        new Autor
                                        {
                                            Id = 2,
                                            Ativo= true,
                                            DataNascimento = new DateTime(2019, 07,09),
                                            Nome = "João Pedro da Silva"
                                        }
                                    };

            var autorAlterado = autores.Where(x => x.Id == id)
                .Select(x => new Autor { 
                    Id = x.Id,
                     Ativo = autor.Ativo,
                      DataNascimento = autor.DataNascimento,
                       Nome = autor.Nome
                }).FirstOrDefault();


            return autorAlterado;
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public List<Autor> Delete(int id)
        {
            var autores = new List<Autor>
                                    {
                                        new Autor
                                        {
                                            Id = 1,
                                            Ativo= true,
                                            DataNascimento = new DateTime(2019, 07,09),
                                            Nome = "João Pedro da Silva"
                                        },
                                        new Autor
                                        {
                                            Id = 2,
                                            Ativo= true,
                                            DataNascimento = new DateTime(2019, 07,09),
                                            Nome = "João Pedro da Silva"
                                        }
                                    };

            autores.RemoveAll(x => x.Id == id);

            return autores;
        }
    }
}
