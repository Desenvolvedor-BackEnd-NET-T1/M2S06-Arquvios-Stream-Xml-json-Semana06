using System.Text.Json;

// Aula 2. [JsonPropertyName], [JsonIgnore] e enum como texto
static class B04_Atributos
{
    public static void Executar()
    {
        PizzaCardapio pizza = new PizzaCardapio
        {
            Sabor = "Portuguesa",
            Preco = 48.50m,
            Custo = 19.00m,
            Tamanho = Tamanho.Grande
        };

        string json =
            JsonSerializer.Serialize(pizza, Json.Opcoes);
        Console.WriteLine(json);

        // Na volta, "nome" preenche a propriedade Sabor
        PizzaCardapio lida = JsonSerializer
            .Deserialize<PizzaCardapio>(json, Json.Opcoes);
        Console.WriteLine(
            $"{lida.Sabor} {lida.Tamanho}, custo {lida.Custo:C}");
    }
}
