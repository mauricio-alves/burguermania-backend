using Microsoft.EntityFrameworkCore;
using WebAPI.Context;

// Cria a aplicação
var builder = WebApplication.CreateBuilder(args); 

// Adiciona os serviços da aplicação
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

// Habilita o uso de banco de dados PostgreSQL
string postgreSQLConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "DefaultConnectionString"; 

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(postgreSQLConnectionString) 
);

// Constrói a aplicação
var app = builder.Build(); 

// Permite a visualização da documentação da API via Swagger
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}

// Redireciona HTTP para HTTPS
if (!app.Environment.IsDevelopment()) 
{
    app.UseHttpsRedirection(); 
}

// Habilita o middleware de autorização
app.UseAuthorization(); 

// Mapeia os controllers
app.MapControllers(); 

// Executa a aplicação
app.Run(); 