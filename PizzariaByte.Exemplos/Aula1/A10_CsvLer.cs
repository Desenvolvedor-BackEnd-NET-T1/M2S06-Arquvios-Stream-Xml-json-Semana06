using System.Globalization;

// Aula 1. Lendo o CSV: cada linha vira um objeto Venda
static class A10_CsvLer
{
    public static void Executar()
    {
        string[] linhas = File.ReadAllLines(
            Path.Combine("entrada", "vendas.csv"));
        List<Venda> vendas = new List<Venda>();

        // Começa no 1: a linha 0 é o cabeçalho
        for (int i = 1; i < linhas.Length; i++)
        {
            string[] colunas = linhas[i].Split(',');
            vendas.Add(new Venda
            {
                Sabor = colunas[0],
                Quantidade = int.Parse(colunas[1]),
                Valor = decimal.Parse(colunas[2],
                    CultureInfo.InvariantCulture)
            });
        }

        foreach (Venda v in vendas)
            Console.WriteLine(
                $"{v.Quantidade}x {v.Sabor}: {v.Valor:C}");

        // Cuidado: sem InvariantCulture, o ponto some
        Console.WriteLine(decimal.Parse("91.80"));
    }
}
