using System.Threading.Channels;
using PizzariaByte.Api.Models;

namespace PizzariaByte.Api.Filas;

// Aula 3. A fila em memória que a API inteira compartilha
// (registrada como Singleton no Program.cs)
public class FilaPedidos
{
    private readonly Channel<Pedido> _canal =
        Channel.CreateUnbounded<Pedido>();

    // O controller coloca o pedido no fim da fila
    public async Task EnfileirarAsync(Pedido pedido)
    {
        await _canal.Writer.WriteAsync(pedido);
    }

    // A cozinha lê um pedido de cada vez
    public IAsyncEnumerable<Pedido> LerAsync(
        CancellationToken parar)
    {
        return _canal.Reader.ReadAllAsync(parar);
    }

    // Quantos pedidos estão esperando
    public int Tamanho
    {
        get { return _canal.Reader.Count; }
    }
}
