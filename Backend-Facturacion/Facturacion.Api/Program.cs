using Facturacion.Aplicacion.Configuracion;
using Facturacion.Infraestructura.Configuracion;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AgregarServiciosAplicacion();
ConfigurarServiciosInfraestructura.AgregarServicios(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin() 
                .AllowAnyHeader() 
                .AllowAnyMethod(); 
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();


app.MapControllers();

app.Run();
