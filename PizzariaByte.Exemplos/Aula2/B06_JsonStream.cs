using System.Text.Json;

// Aula 2. Para conhecer: JSON direto no stream, com async
static class B06_JsonStream
{
    public static async Task Executar()
    {
        string caminho = Path.Combine("dados", "pedidos.json");
        if (!File.Exists(caminho))
        {
            Console.WriteLine("Rode a pratica3 antes.");
            return;
        }

        // Lê do arquivo aos poucos, sem montar a string antes
        List<Pedido> pedidos;
        await using (FileStream leitura =
                     File.OpenRead(caminho))
        {
            pedidos = await JsonSerializer
                .DeserializeAsync<List<Pedido>>(
                    leitura, Json.Opcoes);
        }
        Console.WriteLine($"{pedidos.Count} pedidos lidos");

        // Grava direto no arquivo
        string copia = Path.Combine("dados", "copia.json");
        await using (FileStream escrita = File.Create(copia))
        {
            await JsonSerializer.SerializeAsync(
                escrita, pedidos, Json.Opcoes);
        }
        Console.WriteLine("copia.json gravado");
    }
}
