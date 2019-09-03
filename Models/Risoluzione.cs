using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisneyQuizAppAPI.Models
{
    [Table("RisoluzioniPersonaggi", Schema = "Relazioni")]
    public class Risoluzione
    {
        public int Id { get; set; }
        [Required]
        public int IdGiocatore { get; set; }
        [Required]
        public int IdPersonaggio { get; set; }
    }
}