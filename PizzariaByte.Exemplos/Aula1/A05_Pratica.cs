// Aula 1. Prática: o diário do caixa
static class A05_Pratica
{
    static readonly string Caminho =
        Path.Combine("dados", "caixa.txt");

    public static void Executar()
    {
        Directory.CreateDirectory("dados");
        Registrar("Calabresa", 45.90m);
        Registrar("Margherita", 42.00m);
        Registrar("Portuguesa", 48.50m);
        Mostrar();
    }

    // Acrescenta uma linha assim: 19:42 | Calabresa | R$ 45,90
    static void Registrar(string sabor, decimal valor)
    {
        // 1. Monte a linha com DateTime.Now:HH:mm e valor:C

        // 2. Acrescente a linha no fim do arquivo (Caminho),
        //    sem apagar as anteriores. Use Environment.NewLine
        //    para cada venda ficar em uma linha.
    }

    // Mostra todas as linhas e quantas vendas existem
    static void Mostrar()
    {
        // 1. Leia todas as linhas do arquivo em um array

        // 2. Mostre uma linha por vez

        // 3. Mostre "Vendas no caixa: " e a quantidade
    }
}
