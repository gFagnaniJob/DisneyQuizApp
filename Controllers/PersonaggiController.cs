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
    public class PersonaggiController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public PersonaggiController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpGet("{idLivello}")]
        public async Task<ActionResult<IEnumerable<Personaggio>>> GetPersonaggiLivello(long idLivello)
        {
            var livello = await _context.Livelli.FindAsync(idLivello);

            if (livello == null)
                return BadRequest();

            var personaggi = await _context.Personaggi.Where(personaggio => personaggio.IdLivello == livello.ID).ToListAsync();

            return personaggi;
        }
    }
}