using Microsoft.AspNetCore.Mvc;
using PizzariaByte.Api.Models;
using PizzariaByte.Api.Rabbit;

namespace PizzariaByte.Api.Controllers;

// Aula 3. O mesmo pedido, agora pela fila do RabbitMQ.
// Quem prepara é outro programa: o PizzariaByte.Cozinha.
[ApiController]
[Route("api/pedidos-rabbit")]
public class PedidosRabbitController : ControllerBase
{
    private readonly PublicadorRabbit _publicador;

    public PedidosRabbitController(PublicadorRabbit publicador)
    {
        _publicador = publicador;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(
        NovoPedido novo)
    {
        Pedido pedido = Pedido.Criar(novo);
        await _publicador.PublicarAsync(pedido);

        return Accepted(new
        {
            pedido.Numero,
            Status = "enviado para a cozinha"
        });
    }
}
