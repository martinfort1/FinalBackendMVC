using System.ComponentModel.DataAnnotations;

namespace ProyectoMVC.ViewModel.Modelo
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Categoria { get; set; }
        public string? Cantidad { get; set; }
        public string? Precio { get; set; }
    }
}
