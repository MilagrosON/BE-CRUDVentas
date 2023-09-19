using System.ComponentModel.DataAnnotations;

namespace BE_CRUDVentas.Models
{
    public class Categoria
    {        
        [Key]
        public int idcategoria { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
    }
}
