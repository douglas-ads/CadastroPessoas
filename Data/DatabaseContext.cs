using CadastroPessoas.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoas.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

    }
}
