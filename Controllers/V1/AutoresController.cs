using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLivraria.Context;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Controllers
{
    [ApiController]
    [Route("api/autores")]
    [ApiVersion("1.0", Deprecated = true)]
    public class AutoresController : ControllerBase
    {

        private readonly LivrariaContext _livrariaContext;

        public AutoresController(LivrariaContext livrariaContext)
        {
            _livrariaContext = livrariaContext;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="500"></response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Autor>> Get()
        {
            return await _livrariaContext.Autors.ToListAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="500"></response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _livrariaContext.Autors.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        /// <response code="201"></response>
        /// <response code="404"></response>
        /// <response code="500"></response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Autor autor)
        {
            try
            {
                _livrariaContext.Add(autor);
                await _livrariaContext.SaveChangesAsync();

                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="500"></response>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] Autor autor)
        {
            try
            {
                _livrariaContext.Entry(autor).State = EntityState.Modified;

                await _livrariaContext.SaveChangesAsync();

                return Ok();

            }
            catch
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="500"></response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var autor = await _livrariaContext.Autors.FindAsync(id);

                if (autor == null)
                {
                    return NotFound();
                }

                _livrariaContext.Autors.Remove(autor);
                await _livrariaContext.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
