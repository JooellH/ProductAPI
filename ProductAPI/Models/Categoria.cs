using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProductAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}