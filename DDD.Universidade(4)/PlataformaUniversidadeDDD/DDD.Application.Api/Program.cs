using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//IOC - Dependency Injection
//builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepositorySqlServer>();
builder.Services.AddScoped<ILivroRepository, LivroRepositorySqlServer>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepositorySqlServer>();
builder.Services.AddScoped<IBibliotecariaRepository,  BibliotecariaRepositorySqlServer>();
builder.Services.AddScoped<SqlContext, SqlContext>();


//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// ativar  quando for fazer a inserção no ternário

//Lógica do ternário, comentar para funcionar corretamente

//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// BANCO DE DADOS LOCAL SQLSERVER

builder.Services.AddDbContext<SqlContext>(options =>
{
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BibliotecaDB", sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,     // Número máximo de tentativas de conexão
            maxRetryDelay: TimeSpan.FromSeconds(30), // Tempo máximo entre as tentativas
            errorNumbersToAdd: null // Adicione números de erro personalizados, se necessário
        );
    });
});

// BANCO DE DADOS ONLINE MYSQL

//builder.Services.AddDbContext<SqlContext>(options =>
//{
//    options.UseMySql("Server=db4free.net;Port=3306;Database=navarroonline;User=everton;Password=abcd*123", mySqlOptionsAction: mySqlOptions =>
//    {
//        mySqlOptions.EnableRetryOnFailure(
//            maxRetryCount: 5,     // Número máximo de tentativas de conexão
//            maxRetryDelay: TimeSpan.FromSeconds(30), // Tempo máximo entre as tentativas
//            errorNumbersToAdd: null // Adicione números de erro personalizados, se necessário
//        );
//    },
//    serverVersion: new MySqlServerVersion(new Version(8, 0, 22))); // Substitua pela versão real do seu MySQL
//});



var app = builder.Build();

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
