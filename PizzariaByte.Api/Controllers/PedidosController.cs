using Microsoft.AspNetCore.Mvc;
using PizzariaByte.Api.Filas;
using PizzariaByte.Api.Models;

namespace PizzariaByte.Api.Controllers;

// Aula 3. Recebe o pedido, põe na fila e responde na hora
[ApiController]
[Route("api/pedidos")]
public class PedidosController : ControllerBase
{
    private readonly FilaPedidos _fila;

    public PedidosController(FilaPedidos fila)
    {
        _fila = fila;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(
        NovoPedido novo)
    {
        Pedido pedido = Pedido.Criar(novo);
        await _fila.EnfileirarAsync(pedido);

        // 202 Accepted: "recebi, vou fazer depois"
        return Accepted(new
        {
            pedido.Numero,
            Status = "na fila",
            NaFila = _fila.Tamanho
        });
    }
}
