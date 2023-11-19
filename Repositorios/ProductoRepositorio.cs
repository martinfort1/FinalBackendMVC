using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoMVC.Data;
using ProyectoMVC.ViewModel;
using ProyectoMVC.ViewModel.Modelo;

namespace ProyectoMVC.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly DataContext _context;
        private IMapper _mapper;
        public ProductoRepositorio(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductosViewModel> CrearOActualizar(ProductosViewModel productoDto, int id = 0)
        {
            var productos = productoDto;
            if (id == 0)
            {

                await _context.Productos.AddAsync(productos);
            }
            else
            {
                productos.Id = id; //? solucionar esto 
            }

            await _context.SaveChangesAsync();
            return productos;
        }

        public async Task<bool> DeleteProductos(int id)
        {
            try
            {
                var productos = await _context.Productos.FindAsync(id);
                if (productos != null)
                {
                    _context.Productos.Remove(productos);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ProductosViewModel>> GetProducto()
        {
            var productos = await _context.Productos.ToListAsync();
            //List<productoDto> productoDto = new List<productoDto>();
            //foreach(var persona in personas)
            //{
            //    var productoDto = new productoDto();
            //    productoDto.Nombre = persona.Nombre;
            //    productoDto.Apellido = persona.Apellido;
            //    productoDto.Add(productoDto);

            //}
            return productos;
        }

        public async Task<ProductosViewModel> GetProductosById(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            return productos; ; //! posible error aca
        }

    }
}
