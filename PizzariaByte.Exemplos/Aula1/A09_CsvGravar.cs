using System.Globalization;

// Aula 1. CSV: uma linha por venda, colunas separadas por vírgula
static class A09_CsvGravar
{
    public static void Executar()
    {
        List<Venda> vendas = new List<Venda>
        {
            new Venda { Sabor = "Calabresa",
                Quantidade = 2, Valor = 91.80m },
            new Venda { Sabor = "Margherita",
                Quantidade = 1, Valor = 42.00m },
        };

        // O problema: em português, decimal usa vírgula
        Venda v = vendas[0];
        Console.WriteLine(
            $"{v.Sabor},{v.Quantidade},{v.Valor}");

        // A solução: InvariantCulture escreve com ponto
        Directory.CreateDirectory("dados");
        string caminho =
            Path.Combine("dados", "vendas.csv");
        using (StreamWriter csv =
               new StreamWriter(caminho))
        {
            csv.WriteLine("sabor,quantidade,valor");
            foreach (Venda venda in vendas)
            {
                string valor = venda.Valor.ToString(
                    CultureInfo.InvariantCulture);
                csv.WriteLine(
                    $"{venda.Sabor},{venda.Quantidade},{valor}");
            }
        }
        Console.Write(File.ReadAllText(caminho));
    }
}
