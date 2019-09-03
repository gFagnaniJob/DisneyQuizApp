using System.ComponentModel.DataAnnotations.Schema;

namespace DisneyQuizAppAPI.Models
{
    [Table("Livelli", Schema = "Anagrafica")]
    public class Livello
    {
        public int ID {get; set;}
        public int Numero {get; set;}
    }
}