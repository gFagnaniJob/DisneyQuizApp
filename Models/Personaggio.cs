using System.ComponentModel.DataAnnotations.Schema;

namespace DisneyQuizAppAPI.Models
{
    [Table("Personaggi", Schema = "Anagrafica")]
    public class Personaggio
    {
        public int ID { get; set; }
        public int IdLivello { get; set; }
        public string Nome { get; set; }
        public string Film { get; set; }
        public int Premio { get; set; }
        public int Prezzo { get; set; }
    }
}