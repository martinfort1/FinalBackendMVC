using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMVC.ViewModel
{
    public class ProductosViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [MaxLength(30, ErrorMessage = "El campo no puede ser mayor a 30 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El genero de la pelicula es requerido")]
        [MaxLength(30, ErrorMessage = "El campo no puede ser mayor a 30 caracteres")]

        public string Descripcion { get; set; }
        public string Categoria { get; set; }

        public string Cantidad { get; set; }
        public string Precio { get; set; }
    }
}