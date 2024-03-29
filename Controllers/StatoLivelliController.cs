using System.Linq;
using System.Threading.Tasks;
using DisneyQuizAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisneyQuizAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatoLivelliController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public StatoLivelliController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpGet("IdUtente")]
        public async Task<ActionResult<StatoLivello>> GetStatoLivello(long IdUtente)
        {
            var statoLivello = await _context.StatiLivelli.Where(stato => stato.IdUtente == IdUtente).FirstOrDefaultAsync();

            if (statoLivello == null)
                return NotFound();

            return statoLivello;
        }

        [HttpPut("IdUtente")]
        public async Task<ActionResult> UpdateLivello(long IdUtente)
        {
            var statoLivello = await _context.StatiLivelli.Where(stato => stato.IdUtente == IdUtente).FirstOrDefaultAsync();

            if (statoLivello == null)
                return NotFound();

            statoLivello.IdLivello = statoLivello.IdLivello + 1;

            _context.StatiLivelli.Update(statoLivello);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<StatoLivello>> AddStatoLivello(StatoLivello statoLivello)
        {
          if (!ModelState.IsValid)
            return BadRequest();

          _context.StatiLivelli.Add(statoLivello);
          await _context.SaveChangesAsync();

          return CreatedAtAction(nameof(GetStatoLivello), new {IdUtente = statoLivello.IdUtente}, statoLivello);
        }
    }
}