using System.Data;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.ViewModel;
using ProyectoMVC.ViewModel.Modelo;
namespace ProyectoMVC.Controllers
{
    public class AppController : Controller
    {
        private static List<ProductosViewModel> _producto = new List<ProductosViewModel>();
        public IActionResult Index()
        {
            return View(_producto);
        }
        public IActionResult Edit(Guid id)
        {
            var producto = _producto.FirstOrDefault(x => x.Id == id);
            return View(producto);
        }
        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(ProductosViewModel modelo)
        {
            var producto = _producto.FirstOrDefault(x => x.Id == modelo.Id);
            if (ModelState.IsValid)
            {
                if (producto == null)
                {
                    modelo.Id = Guid.NewGuid();
                    _producto.Add(modelo);
                }
                else
                {
                    producto.Nombre = modelo.Nombre;
                    producto.Descripcion = modelo.Descripcion;
                    producto.Categoria = modelo.Categoria;
                    producto.Precio = modelo.Precio;
                    producto.Cantidad = modelo.Cantidad;

                }
                return RedirectToAction(nameof(Index));
                // codigo para insertar en BD
            }
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            var producto = _producto.FirstOrDefault(x => x.Id == id);
            if (producto != null)
            {
                _producto.Remove(producto);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

