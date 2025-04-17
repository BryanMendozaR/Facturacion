using Facturacion.Aplicacion.Configuracion;
using Facturacion.Infraestructura.Configuracion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AgregarServiciosAplicacion();
ConfigurarServiciosInfraestructura.AgregarServicios(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
