using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Controllers
{
    [Route("api/autores")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        // GET: api/<AutoresController>
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

        // GET api/<AutoresController>/5
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

        // PUT api/<AutoresController>/5
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

        // DELETE api/<AutoresController>/5
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
