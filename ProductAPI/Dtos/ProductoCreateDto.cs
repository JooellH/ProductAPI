using System.ComponentModel.DataAnnotations;
public class ProductoCreateDto
{
    [Required]
    public string Nombre { get; set; }

    [Required]
    public decimal Precio { get; set; }

    [Required]
    public int CategoriaId { get; set; }
}