namespace PizzariaByte.Cozinha;

// O mesmo formato do pedido que a API publica
public class Pedido
{
    public int Numero { get; set; }
    public string Cliente { get; set; }
    public List<string> Pizzas { get; set; }
}
