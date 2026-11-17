using System.Text.Json;

// Aula 2. Desserializar: texto JSON vira objeto C#
static class B02_Desserializar
{
    public static void Executar()
    {
        string caminho =
            Path.Combine("dados", "pedido-1001.json");
        string json = File.ReadAllText(caminho);

        // <Pedido> diz qual classe preencher
        Pedido pedido =
            JsonSerializer.Deserialize<Pedido>(json);

        Console.WriteLine(
            $"Pedido {pedido.Numero} de {pedido.Cliente}");
        foreach (ItemPedido item in pedido.Itens)
            Console.WriteLine(
                $"  {item.Quantidade}x {item.Sabor} {item.Preco:C}");

        // Atenção: aqui maiúscula e minúscula fazem diferença
        string outro = """{ "numero": 1002, "cliente": "Bia" }""";
        Pedido p2 = JsonSerializer.Deserialize<Pedido>(outro);
        Console.WriteLine($"Pedido {p2.Numero} de {p2.Cliente}");
    }
}
