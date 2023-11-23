using ProyectoMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMVC.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<List<ProductosViewModel>> GetProducto();
        Task<ProductosViewModel?> GetProductosById(Guid id);  // Cambiado el tipo de id a Guid
        Task<ProductosViewModel> CrearOActualizar(ProductosViewModel productos, Guid id = default);
        Task<bool> DeleteProductos(Guid id);  // Cambiado el tipo de id a Guid
    }
}
