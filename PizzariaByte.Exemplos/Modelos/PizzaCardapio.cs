using System.Text.Json.Serialization;

// Aula 2. Atributos mudam como cada propriedade vira JSON
public class PizzaCardapio
{
    // No JSON, o campo se chama "nome"
    [JsonPropertyName("nome")]
    public string Sabor { get; set; }

    public decimal Preco { get; set; }

    // Informação interna: não sai no JSON
    [JsonIgnore]
    public decimal Custo { get; set; }

    public Tamanho Tamanho { get; set; }
}

// O enum sai como texto ("Grande") em vez de número (2)
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Tamanho { Broto, Media, Grande }
