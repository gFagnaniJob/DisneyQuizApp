using Microsoft.EntityFrameworkCore;

namespace DisneyQuizAppAPI.Models
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
        }

        public DbSet<Personaggio> Personaggi { get; set; }
        public DbSet<Livello> Livelli { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Risoluzione> Risoluzioni { get; set; }
    }
}