using Microsoft.EntityFrameworkCore;
using WebApiLibros.Models;

namespace WebApiLibros.Data
{
    public class DBLibrosContext: DbContext
    {
        public DBLibrosContext(DbContextOptions<DBLibrosContext> options): base (options) { }

        public DbSet <Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
