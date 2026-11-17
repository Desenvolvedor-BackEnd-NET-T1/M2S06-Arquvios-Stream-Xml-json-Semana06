using PizzariaByte.Api.Filas;
using PizzariaByte.Api.Rabbit;
using RabbitMQ.Client;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;

// Aula 3, parte 1. Fila em memória
// Uma fila só, para a API inteira
builder.Services.AddSingleton<FilaPedidos>();
// A cozinha roda em segundo plano
builder.Services.AddHostedService<CozinhaWorker>();

// Aula 3, parte 2. RabbitMQ
// A URL fica no User Secrets. Sem ela, a API sobe sem
// o RabbitMQ (só a rota api/pedidos funciona).
string urlRabbit = config["RabbitMQ:Url"];
if (urlRabbit != null)
{
    // Abrir conexão é caro: abre uma vez e reaproveita
    var fabrica = new ConnectionFactory
    {
        Uri = new Uri(urlRabbit)
    };
    IConnection conexao = await fabrica.CreateConnectionAsync();
    builder.Services.AddSingleton(conexao);
    builder.Services.AddSingleton<PublicadorRabbit>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
