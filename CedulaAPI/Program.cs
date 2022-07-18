using CedulaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProyectoMobileContext>(opt => {
    opt.UseSqlServer("workstation id=dbCedula.mssql.somee.com;packet size=4096;user id=emi0204_SQLLogin_1;pwd=vblh2mnyd8;data source=dbCedula.mssql.somee.com;persist security info=False;initial catalog=dbCedula");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CedulaOrigins",
                      builder =>
                      {
                          builder.
                            AllowAnyOrigin()
                           .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CedulaOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
