using ToDoList.Models.DB;
using ToDoList.Repository.Interface;
using ToDoList.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//Cadena de coneccion a la base de datos
var conectionString = builder.Configuration.GetConnectionString("DebConnection");
builder.Services.AddScoped(x => new ToDoContext(conectionString));

//Se añaden los repositorios
builder.Services.AddScoped<ITareasRepository, TareasRepository>();
builder.Services.AddScoped<IEstadosRepository, EstadosRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("Politica", buil => {
    buil.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Politica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
