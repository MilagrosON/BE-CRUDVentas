using System.ComponentModel.DataAnnotations;

namespace BE_CRUDVentas.Models
{
    public class TipoUsuario
    {        
        [Key]
        public int idusuario { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
    }
}
