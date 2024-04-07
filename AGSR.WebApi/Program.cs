using AGSR.WebApi.Domain.Context;
using AGSR.WebApi.Domain.Extensions;
using AGSR.WebApi.Kernel.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKernelServices();
builder.Services.AddConfigDbContext();
builder.Services.AddRepositories();

builder.Services.AddControllers();
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

var logger = app.Services.GetRequiredService<ILogger<Program>>();

AddMigrations(app);

app.Run();

void AddMigrations(WebApplication webApplication)
{
    using var scope = webApplication.Services.CreateScope();

    try
    {
        var context = scope.ServiceProvider.GetService<ConfigContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, ex.Message);
    }
}