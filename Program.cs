using API_Biblioteca.Data_Access_Layer.Implementations;
using API_Biblioteca.Data_Access_Layer.Interfaces;
using APIBiblioteca.Data_Access_Layer.DataContext;
using APIBiblioteca.Data_Access_Layer.Implementations;
using APIBiblioteca.Data_Access_Layer.Interfaces;
using APIBiblioteca.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSql")));

//Esta linea de código registra servicios en  el contenedor de dependencias.
//Suele encontrarse en el archivo de config de servicios, como Program.cs o Startup.cs, en una app ASP.NET Core.
//Se utiliza para configurar como se crean y administran las dependencias.
//builder.services es el contenedor de servicios de la app, donde registramos las dependencias que se inyectaran en los controladores u otras partes de la app.
//AddTransient es un metodo que registra un servicio con un ciclo de vida transitorio, cada vez que se solicita el servicio se crea una nueva instancia y es util para servicios ligeros y sin estado.
//typeof(IGenericRepository<>) indica que se esta registrando una interfaz generica, en este caso un repositorio que contiene metodos CRUD.
//typeof(GenericRepository<>) es la implementación concreta de la interfaz IGenericRepository<T>, seria la clase que contiene la lógica para interactuar con la base de datos.
//En programación, "la implementación" es la que "implementa" la otra, es decir, el que proporciona el comportamiento real.
//Inyectamos las dependencias de la interfaz de genero, como la clase. Para dejar en claro que clase implementará cual interfaz.
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
