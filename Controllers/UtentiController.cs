using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisneyQuizAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DisneyQuizAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtentiController : ControllerBase
    {
        private readonly SqlServerContext _context;
        private readonly ILogger _logger;

        public UtentiController(SqlServerContext context, ILogger<UtentiController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utente>>> GetUsers ()
        {
            _logger.LogError("GET api/utenti");
            return await _context.Utenti.ToListAsync();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Utente>> GetUser(string username)
        {
            var utente = await _context.Utenti.Where(user => user.Username == username).FirstOrDefaultAsync();

            if (utente == null)
                return NotFound();

            return utente;
        }

        [HttpPost]
        public async Task<ActionResult<Utente>> RegisterUser(Utente utente)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            utente.Monete = 0;
            
            _context.Utenti.Add(utente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = utente.Id }, utente);
        }
    }
}