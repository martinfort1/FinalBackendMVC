using Microsoft.EntityFrameworkCore;
using ProyectoMVC.ViewModel;
using ProyectoMVC.ViewModel.Modelo;
using System.Collections.Generic;

namespace ProyectoMVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<ProductosViewModel> Productos { get; set; }
    }
}
