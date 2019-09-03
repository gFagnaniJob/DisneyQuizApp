using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisneyQuizAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisneyQuizAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RisoluzioniController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public RisoluzioniController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpGet("username")]
        public async Task<ActionResult<IEnumerable<Personaggio>>> GetRisoluzioniUtente(string username)
        {
            var utente = await _context.Utenti.Where(user => user.Username == username).FirstOrDefaultAsync();

            if (utente == null)
                return BadRequest();

            var risoluzioni = await _context.Risoluzioni.Where(risoluzione => risoluzione.IdGiocatore == utente.Id).ToListAsync();

            List<Personaggio> personaggi = new List<Personaggio>();

            foreach (var ris in risoluzioni)
            {
                var personaggio = await _context.Personaggi.FindAsync(ris.Id);

                if (personaggio != null)
                    personaggi.Add(personaggio);
            }

            return personaggi;
        }

        [HttpPost]
        public async Task<ActionResult<Risoluzione>> AddRisoluzione(Risoluzione risoluzione)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var utente = await _context.Utenti.FindAsync(risoluzione.IdGiocatore);
            if (utente == null)
                return BadRequest();

            var personaggio = await _context.Personaggi.FindAsync(risoluzione.IdPersonaggio);
            if (personaggio == null)
                return BadRequest();
            
            _context.Risoluzioni.Add(risoluzione);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRisoluzioniUtente), new {username = utente.Username}, risoluzione);
        }
    }
}