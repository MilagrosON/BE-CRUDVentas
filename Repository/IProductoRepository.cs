using BE_CRUDVentas.Models;

namespace BE_CRUDVentas.Repository
{
    public interface IProductoRepository
    {
        Task<List<ProductoRel>> GetListProductos();

        Task<ProductoRel> GetProducto(int id);

        Task<Producto> GetOnlyProducto(int id);

        Task<List<TipoUsuario>> GetListTipoUsuarios();

        Task<List<Categoria>> GetListCategorias();

        Task<Categoria> GetCategoria(int id);

        Task<Producto> AddProducto(Producto producto);

        Task UpdateProducto(Producto producto);

        Task DeleteProducto(Producto producto);
    }
}
