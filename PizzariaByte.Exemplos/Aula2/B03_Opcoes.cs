using System.Text.Json;

// Aula 2. As mesmas operações, agora com Json.Opcoes
static class B03_Opcoes
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
                    Quantidade = 2, Preco = 45.90m }
            }
        };

        string json =
            JsonSerializer.Serialize(pedido, Json.Opcoes);
        Console.WriteLine(json);

        // Agora "numero" e "cliente" em minúsculas funcionam
        string outro = """{ "numero": 1002, "cliente": "Bia" }""";
        Pedido p2 = JsonSerializer.Deserialize<Pedido>(
            outro, Json.Opcoes);
        Console.WriteLine($"Pedido {p2.Numero} de {p2.Cliente}");
    }
}
