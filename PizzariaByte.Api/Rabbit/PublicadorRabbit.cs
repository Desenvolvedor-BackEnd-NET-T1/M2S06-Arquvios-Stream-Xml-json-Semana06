using System.Text.Json;
using PizzariaByte.Api.Models;
using RabbitMQ.Client;

namespace PizzariaByte.Api.Rabbit;

// Aula 3. Publica o pedido numa fila do RabbitMQ, fora da API
public class PublicadorRabbit
{
    private readonly IConnection _conexao;
    private readonly string _fila;

    public PublicadorRabbit(IConnection conexao,
                            IConfiguration config)
    {
        _conexao = conexao;
        _fila = config["RabbitMQ:Fila"];
    }

    public async Task PublicarAsync(Pedido pedido)
    {
        // Canal: uma conversa dentro da conexão (é barato)
        await using IChannel canal =
            await _conexao.CreateChannelAsync();

        // Cria a fila se ela ainda não existir.
        // durable: a fila continua lá se o RabbitMQ reiniciar
        await canal.QueueDeclareAsync(_fila, durable: true,
            exclusive: false, autoDelete: false);

        // A mensagem é um array de bytes: o pedido em JSON
        byte[] corpo =
            JsonSerializer.SerializeToUtf8Bytes(pedido);

        // Persistent: a mensagem é gravada em disco
        var props = new BasicProperties { Persistent = true };

        // exchange "": entrega direto na fila com esse nome
        await canal.BasicPublishAsync(exchange: "",
            routingKey: _fila, mandatory: false,
            basicProperties: props, body: corpo);
    }
}
