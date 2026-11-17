using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PizzariaByte.Cozinha;

// Aula 3. A cozinha agora é outro programa: ela lê a fila
// do RabbitMQ, mesmo que a API esteja em outro computador
public class CozinhaRabbit : BackgroundService
{
    private readonly IConfiguration _config;

    public CozinhaRabbit(IConfiguration config)
    {
        _config = config;
    }

    protected override async Task ExecuteAsync(
        CancellationToken parar)
    {
        // A URL fica no User Secrets, nunca no código
        string url = _config["RabbitMQ:Url"];
        if (url == null)
        {
            Hora("Falta a URL. Rode: dotnet user-secrets set " +
                 "RabbitMQ:Url \"amqps://...\"");
            return;
        }

        var fabrica = new ConnectionFactory { Uri = new Uri(url) };
        await using IConnection conexao =
            await fabrica.CreateConnectionAsync(parar);
        await using IChannel canal =
            await conexao.CreateChannelAsync(
                cancellationToken: parar);

        // Mesma declaração da API: quem chegar primeiro cria
        string fila = _config["RabbitMQ:Fila"];
        await canal.QueueDeclareAsync(fila, durable: true,
            exclusive: false, autoDelete: false,
            cancellationToken: parar);

        // Só manda o próximo depois que este terminar
        await canal.BasicQosAsync(0, prefetchCount: 1,
            global: false, parar);

        var consumidor = new AsyncEventingBasicConsumer(canal);
        consumidor.ReceivedAsync += async (sender, msg) =>
        {
            await Preparar(msg.Body.ToArray());

            // ack: "terminei, pode apagar da fila"
            await canal.BasicAckAsync(msg.DeliveryTag,
                multiple: false);
        };

        // autoAck: false. A mensagem só sai da fila com o ack.
        await canal.BasicConsumeAsync(fila, autoAck: false,
            consumer: consumidor, cancellationToken: parar);
        Hora($"Cozinha aberta, esperando a fila {fila}");

        // Fica rodando até o Ctrl+C
        await Task.Delay(Timeout.Infinite, parar);
    }

    private static async Task Preparar(byte[] corpo)
    {
        string json = Encoding.UTF8.GetString(corpo);
        Pedido pedido = JsonSerializer.Deserialize<Pedido>(json);
        string pizzas = string.Join(", ", pedido.Pizzas);
        Hora($"Preparando {pedido.Numero}: {pizzas}");

        await Task.Delay(5000); // o forno

        Directory.CreateDirectory("prontos");
        await File.WriteAllTextAsync(Path.Combine("prontos",
            $"pedido-{pedido.Numero}.json"), json);
        Hora($"{pedido.Numero} pronto para {pedido.Cliente}");
    }

    private static void Hora(string texto)
    {
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} {texto}");
    }
}
