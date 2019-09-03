using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisneyQuizAppAPI.Models
{
  [Table("StatoLivelli", Schema = "Relazioni")]
  public class StatoLivello
  {
    public int Id {get; set;}
    [Required]
    public int IdUtente {get; set;}
    [Required]
    public int IdLivello {get; set;}
  }
}