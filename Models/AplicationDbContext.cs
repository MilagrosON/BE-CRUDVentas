using Microsoft.EntityFrameworkCore;//add

namespace BE_CRUDVentas.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }                
        public DbSet<Producto> producto { get; set; }
        public DbSet<ProductoRel> Producto { get; set; }
        public DbSet<Categoria>categoria { get; set; }
        public DbSet<TipoUsuario>tipoUsuario { get; set; }
    }
}
