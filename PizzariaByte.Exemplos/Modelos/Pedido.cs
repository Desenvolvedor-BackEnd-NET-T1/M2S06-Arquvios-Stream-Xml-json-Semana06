// Aula 2. Um pedido com vários itens
public class Pedido
{
    public int Numero { get; set; }
    public string Cliente { get; set; }
    public List<ItemPedido> Itens { get; set; }
}

public class ItemPedido
{
    public string Sabor { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}
