using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public async Task<ProductosViewModel> CrearOActualizar(ProductosViewModel productoDto, Guid id)
        {
            var productos = productoDto;
            if (id == Guid.Empty)
            {

                await _context.Productos.AddAsync(productos); // crear 
            }
            else
            {
                productos.Id = id; //actualiza

            }

            await _context.SaveChangesAsync();
            return productos;
        }

        public async Task<bool> DeleteProductos(Guid id)
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
            catch (Exception) // posible error aca volver a agregar ex o _
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

        public async Task<ProductosViewModel?> GetProductosById(Guid id)//agregar ? 
        {
            var productos = await _context.Productos.FindAsync(id);
            if(productos != null)
            {
                return productos;
            }
            else //agregar
            {
                return null;
            }
        }

    }
}
