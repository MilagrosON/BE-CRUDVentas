using BE_CRUDVentas.Models;//add
using AutoMapper;//add
using Microsoft.AspNetCore.Mvc;
using BE_CRUDVentas.Repository;

namespace BE_CRUDVentas.Controllers
{
    [Route("api/[controller]")]//add
    [ApiController]//add
    public class TipoUsuarioController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProductoRepository _productoRepository;

        public TipoUsuarioController(IMapper mapper, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {                
                var listTipoUsuarios = await _productoRepository.GetListTipoUsuarios();                
                var listTipoUsuariosDto = _mapper.Map<IEnumerable<TipoUsuario>>(listTipoUsuarios);

                return Ok(listTipoUsuariosDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
