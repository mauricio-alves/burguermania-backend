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

// Adiciona o contexto do banco de dados
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(postgreSQLConnectionString) 
);

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200") 
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Constrói a aplicação
var app = builder.Build(); 

// Permite a visualização da documentação da API via Swagger
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger(); 
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
    });
}

// Redireciona HTTP para HTTPS
if (!app.Environment.IsDevelopment()) 
{
    app.UseHttpsRedirection(); 
}

// Adiciona o middleware de CORS
app.UseCors("AllowAngular");

// Habilita o middleware de autorização
app.UseAuthorization(); 

// Mapeia os controllers
app.MapControllers(); 

// Executa a aplicação
app.Run(); 