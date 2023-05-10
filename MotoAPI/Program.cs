using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MotoAPI;
using MotoAPI.Entitites;
using MotoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MotoSeeder>();
builder.Services.AddDbContext<MotoDbContext>
(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MotoDbConnection")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IMotoService, MotoService>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<MotoSeeder>();

seeder.Seed();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();