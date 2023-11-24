using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoMVC;
using ProyectoMVC.Data;
using ProyectoMVC.Repositorios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration
.GetConnectionString("DefaultConnection")));

IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
//app.MapGet("/", () => "Hello World!");
//app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(x =>
{
	x.MapRazorPages();
	x.MapControllerRoute(
		name: "Default",
		pattern: "{controller}/{action}/{id?}",
		defaults: new { Controller = "App", Action = "Index" }
	);
});







app.Run();
