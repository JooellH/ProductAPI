using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Precio { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}