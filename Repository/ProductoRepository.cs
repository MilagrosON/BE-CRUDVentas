using BE_CRUDVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_CRUDVentas.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AplicationDbContext _context;

        public ProductoRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductoRel>> GetListProductos()
        {
            //return await //_context.producto.Where<Producto>(x => x.estado == true).ToListAsync();
            return await _context.Producto.Include(e => e.id).Where< ProductoRel > (x => x.estado == true).ToListAsync();
        }

        public async Task<ProductoRel> GetProducto(int id)
        {
            //return await _context.producto.FindAsync(id);
            return await _context.Producto.Include(e => e.id).FirstAsync<ProductoRel>(x => x.idproducto == id);
        }

        public async Task<Producto> GetOnlyProducto(int id)
        {
            return await _context.producto.FindAsync(id);            
        }

        public async Task<Producto> AddProducto(Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task UpdateProducto(Producto producto)
        {
            var productoItem = await _context.producto.FirstOrDefaultAsync(x => x.idproducto == producto.idproducto);

            if (productoItem != null)
            {
                productoItem.nombre = producto.nombre;
                productoItem.idcategoria = producto.idcategoria;
                productoItem.precio_venta = producto.precio_venta;
                productoItem.stock = producto.stock;                
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteProducto(Producto producto)
        {
            _context.producto.Remove(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Categoria>> GetListCategorias()
        {
            return await _context.categoria.Where<Categoria>(x => x.estado == true).ToListAsync();
        }

        public async Task<List<TipoUsuario>> GetListTipoUsuarios()
        {
            return await _context.tipoUsuario.Where<TipoUsuario>(x => x.estado == true).ToListAsync();
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return await _context.categoria.FindAsync(id);
        }

    }
}
