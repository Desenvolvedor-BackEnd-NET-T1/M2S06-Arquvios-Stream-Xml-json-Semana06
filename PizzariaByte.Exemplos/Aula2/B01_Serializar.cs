using System.Text.Json;

// Aula 2. Serializar: objeto C# vira texto JSON
static class B01_Serializar
{
    public static void Executar()
    {
        Pedido pedido = new Pedido
        {
            Numero = 1001,
            Cliente = "João",
            Itens = new List<ItemPedido>
            {
                new ItemPedido { Sabor = "Calabresa",
                    Quantidade = 2, Preco = 45.90m },
                new ItemPedido { Sabor = "Margherita",
                    Quantidade = 1, Preco = 42.00m }
            }
        };

        // Objeto -> texto JSON, numa linha só
        string json = JsonSerializer.Serialize(pedido);
        Console.WriteLine(json);

        // Grava o texto num arquivo (como na aula 1)
        Directory.CreateDirectory("dados");
        File.WriteAllText(
            Path.Combine("dados", "pedido-1001.json"), json);
    }
}
