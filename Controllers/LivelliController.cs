using System.Linq;
using System.Threading.Tasks;
using DisneyQuizAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisneyQuizAppAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LivelliController : ControllerBase
  {
    private readonly SqlServerContext _context;

    public LivelliController(SqlServerContext context)
    {
      _context = context;
    }

    [HttpGet("{numero}")]
    public async Task<ActionResult<Livello>> GetLivello(int numero)
    {
        var livello = await _context.Livelli.Where(livello => livello.Numero == numero).FirstOrDefaultAsync();

        if (livello == null)
            return BadRequest();

        return livello;
    }
  }
}