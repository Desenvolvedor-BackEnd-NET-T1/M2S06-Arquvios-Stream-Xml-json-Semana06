namespace PizzariaByte.Api.Models;

// Aula 3. O que o cliente manda no POST
public class NovoPedido
{
    public string Cliente { get; set; }
    public List<string> Pizzas { get; set; }
}

// O pedido que vai para a fila, já com número
public class Pedido
{
    public int Numero { get; set; }
    public string Cliente { get; set; }
    public List<string> Pizzas { get; set; }

    private static int _ultimo = 1000;

    public static Pedido Criar(NovoPedido novo)
    {
        return new Pedido
        {
            // Interlocked: soma 1 com segurança, mesmo com
            // várias requisições ao mesmo tempo (semana 04)
            Numero = Interlocked.Increment(ref _ultimo),
            Cliente = novo.Cliente,
            Pizzas = novo.Pizzas
        };
    }
}
