using PizzariaByte.Cozinha;

// Aula 3. Um programa sem tela e sem rotas: só a cozinha,
// rodando em segundo plano (projeto do tipo Worker Service)
Console.OutputEncoding = System.Text.Encoding.UTF8;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<CozinhaRabbit>();

var host = builder.Build();
host.Run();
