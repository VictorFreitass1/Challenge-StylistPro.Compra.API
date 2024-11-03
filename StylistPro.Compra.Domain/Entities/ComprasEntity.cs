using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StylistPro.Compra.Domain.Entities
{
    [Table("TB_COMPRAS")]
    public class ComprasEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataDaCompra { get; set; }
        public string Status { get; set; } = string.Empty;

    }
}
