using BE_CRUDVentas.Models;//add
using AutoMapper;//add
using Microsoft.AspNetCore.Mvc;
using BE_CRUDVentas.Repository;

namespace BE_CRUDVentas.Controllers
{
    [Route("api/[controller]")]//add
    [ApiController]//add
    public class ProductoController: ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IMapper mapper, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {                
                var listProductos = await _productoRepository.GetListProductos();                
                var listProductosDto = _mapper.Map<IEnumerable<ProductoRel>>(listProductos);

                return Ok(listProductosDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var producto = await _productoRepository.GetProducto(id);

                if (producto == null)
                {
                    return NotFound();
                }

                var productoDto = _mapper.Map<ProductoRel>(producto);

                return Ok(productoDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Producto productoDto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDto);
                //producto.FechaCreacion = DateTime.Now;            
                producto.precio_venta = Convert.ToDecimal(producto.precio_venta);
                producto = await _productoRepository.AddProducto(producto);

                var productoItemDto = _mapper.Map<Producto>(producto);

                return CreatedAtAction("Get", new { id = productoItemDto.idproducto }, productoItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Producto productoDto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDto);
                producto.precio_venta = Convert.ToDecimal(producto.precio_venta);
                if (id != producto.idproducto)
                {
                    return BadRequest();
                }

                var productoItem = await _productoRepository.GetProducto(id);

                if (productoItem == null)
                {
                    return NotFound();
                }

                await _productoRepository.UpdateProducto(producto);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var producto = await _productoRepository.GetOnlyProducto(id);

                if (producto == null)
                {
                    return NotFound();
                }

                await _productoRepository.DeleteProducto(producto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
