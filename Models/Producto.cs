using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_CRUDVentas.Models
{
    public class Producto
    {

        [Key]
        public int idproducto { get; set; }       
        public int idcategoria { get; set; }
        public string nombre { get; set; }

        [Column(TypeName = "decimal(11,2)")]
        public decimal precio_venta { get; set; }

        public int stock { get; set; }
        public bool estado { get; set; }
        
    }
}
