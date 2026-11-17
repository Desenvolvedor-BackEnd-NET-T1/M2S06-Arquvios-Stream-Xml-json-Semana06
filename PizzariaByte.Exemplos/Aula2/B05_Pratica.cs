using System.Text.Json;

// Aula 2. Prática: os pedidos do dia continuam no arquivo
// depois que o programa fecha
static class B05_Pratica
{
    static readonly string Caminho =
        Path.Combine("dados", "pedidos.json");

    public static void Executar()
    {
        List<Pedido> pedidos = Carregar();
        Console.WriteLine($"Pedidos no arquivo: {pedidos.Count}");

        Pedido novo = new Pedido
        {
            Numero = 1001 + pedidos.Count,
            Cliente = "Mesa " + (pedidos.Count + 1),
            Itens = new List<ItemPedido>
            {
                new ItemPedido { Sabor = "Calabresa",
                    Quantidade = 1, Preco = 45.90m }
            }
        };
        pedidos.Add(novo);
        Salvar(pedidos);
        Console.WriteLine($"Pedido {novo.Numero} salvo");
    }

    // Lê a lista do arquivo. Se ele ainda não existe,
    // começa com uma lista vazia.
    static List<Pedido> Carregar()
    {
        // 1. Se o arquivo (Caminho) não existe, devolva uma
        //    lista vazia

        // 2. Se existe, leia o texto e transforme em
        //    List<Pedido> com JsonSerializer.Deserialize,
        //    usando Json.Opcoes

        return new List<Pedido>(); // apague esta linha
    }

    // Grava a lista inteira, por cima do arquivo antigo
    static void Salvar(List<Pedido> pedidos)
    {
        // 1. Garanta que a pasta dados existe

        // 2. Transforme a lista em JSON com
        //    JsonSerializer.Serialize e Json.Opcoes

        // 3. Grave o texto no arquivo (Caminho)
    }
}
