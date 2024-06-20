using PECANO.API.Service;
using PECANO.API.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Register the strategies
builder.Services.AddSingleton<ObreroCalculoSueldoStrategy>();
builder.Services.AddSingleton<SupervisorCalculoSueldoStrategy>();
builder.Services.AddSingleton<GerenteCalculoSueldoStrategy>();

// Register the context and service
builder.Services.AddSingleton<CalculoSueldoContext>();
builder.Services.AddSingleton<TrabajadorService>();



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
