using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisneyQuizAppAPI.Models
{
    [Table("Utenti", Schema = "Anagrafica")]
    public class Utente
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int Monete { get; set; }
    }
}