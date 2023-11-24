using AutoMapper;
using ProyectoMVC.ViewModel;
using ProyectoMVC.ViewModel.Modelo;

namespace ProyectoMVC
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductosViewModel, Producto>();
                config.CreateMap<Producto, ProductosViewModel>();
            });
            return mappingConfig;
        }
    }
}
