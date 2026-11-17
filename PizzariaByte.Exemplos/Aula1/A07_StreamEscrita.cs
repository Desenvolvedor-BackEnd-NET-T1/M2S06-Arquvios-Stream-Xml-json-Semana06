// Aula 1. StreamWriter: grava aos poucos, linha a linha
static class A07_StreamEscrita
{
    public static void Executar()
    {
        Directory.CreateDirectory("dados");
        string caminho = Path.Combine("dados", "pedidos.log");

        // using: fecha o arquivo no fim do bloco,
        // mesmo se acontecer um erro no meio
        using (StreamWriter escritor =
               new StreamWriter(caminho))
        {
            for (int n = 1; n <= 100_000; n++)
                escritor.WriteLine($"Pedido {n} entregue");
        }

        FileInfo info = new FileInfo(caminho);
        Console.WriteLine($"{info.Length / 1024} KB gravados");

        // append: true acrescenta em vez de substituir
        using (StreamWriter escritor =
               new StreamWriter(caminho, append: true))
        {
            escritor.WriteLine("Fim do expediente");
        }
        Console.WriteLine("Última linha acrescentada");
    }
}
