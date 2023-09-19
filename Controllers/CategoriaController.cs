using BE_CRUDVentas.Models;//add
using AutoMapper;//add
using Microsoft.AspNetCore.Mvc;
using BE_CRUDVentas.Repository;
using Microsoft.EntityFrameworkCore;

namespace BE_CRUDVentas.Controllers
{
    [Route("api/[controller]")]//add
    [ApiController]//add
    public class CategoriaController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProductoRepository _productoRepository;

        public CategoriaController(IMapper mapper, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {                
                var listCategorias = await _productoRepository.GetListCategorias();                
                var listCategoriasDto = _mapper.Map<IEnumerable<Categoria>>(listCategorias);

                return Ok(listCategoriasDto);
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
                var categoria = await _productoRepository.GetCategoria(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                var categoriaDto = _mapper.Map<Categoria>(categoria);

                return Ok(categoriaDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
