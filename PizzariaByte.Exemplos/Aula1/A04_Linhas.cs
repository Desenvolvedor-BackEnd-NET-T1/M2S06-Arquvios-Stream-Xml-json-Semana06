// Aula 1. Linha por linha: cada linha vira um item do array
static class A04_Linhas
{
    public static void Executar()
    {
        string cardapio =
            Path.Combine("entrada", "cardapio.txt");
        string[] sabores = File.ReadAllLines(cardapio);

        Console.WriteLine($"{sabores.Length} sabores:");
        for (int i = 0; i < sabores.Length; i++)
            Console.WriteLine($"{i + 1}. {sabores[i]}");

        // O caminho inverso: um item do array por linha
        string[] promocao = { "Calabresa", "Margherita" };
        Directory.CreateDirectory("dados");
        File.WriteAllLines(
            Path.Combine("dados", "promocao.txt"), promocao);
        Console.WriteLine("promocao.txt gravado");
    }
}
