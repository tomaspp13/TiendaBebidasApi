using Aplication.Commands.BebidaCommands.CrearBebida;
using Aplication.Commands.UsuarioCommands.CrearUsuario;
using Domain.Interfaces.Repositories;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBebidaRepository,BebidaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPasswordHasher,PasswordHasher>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CrearBebidaCommand).Assembly));
builder.Services.AddAutoMapper(typeof(CrearBebidaCommand).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
