using System.Text.Json;
using PizzariaByte.Api.Filas;
using PizzariaByte.Api.Models;

namespace PizzariaByte.Api.Filas;

// Aula 3. A cozinha: roda em segundo plano, junto com a API,
// desde que ela sobe até ela ser desligada
public class CozinhaWorker : BackgroundService
{
    private readonly FilaPedidos _fila;

    public CozinhaWorker(FilaPedidos fila)
    {
        _fila = fila;
    }

    protected override async Task ExecuteAsync(
        CancellationToken parar)
    {
        Directory.CreateDirectory("prontos");

        // Espera o próximo pedido, sem gastar processador
        await foreach (Pedido pedido in _fila.LerAsync(parar))
        {
            Hora($"Cozinha: preparando {pedido.Numero}");
            await Task.Delay(5000, parar); // o forno

            // Pedido pronto vira um arquivo JSON (aula 2)
            string json = JsonSerializer.Serialize(pedido);
            string arquivo = Path.Combine("prontos",
                $"pedido-{pedido.Numero}.json");
            await File.WriteAllTextAsync(arquivo, json, parar);
            Hora($"Cozinha: {pedido.Numero} pronto");
        }
    }

    private static void Hora(string texto)
    {
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} {texto}");
    }
}
