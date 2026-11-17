using System.Globalization;

// Aula 1. Prática: o relatório de vendas por sabor
static class A11_Pratica
{
    public static void Executar()
    {
        // 1. Ler o CSV entrada/vendas.csv (igual ao csv-ler).
        //    Lembre: a linha 0 é o cabeçalho.

        // 2. Somar o valor de cada sabor em um
        //    Dictionary<string, decimal> e o total geral.
        //    Use decimal.Parse com CultureInfo.InvariantCulture.
        //    Se o sabor ainda não está no dicionário
        //    (ContainsKey), comece com 0.

        // 3. Gravar o relatório em dados/relatorio.txt com
        //    StreamWriter: o título "VENDAS POR SABOR", uma linha
        //    por sabor e uma linha com o TOTAL.
        //    Dica para alinhar: {sabor,-20}{valor,10:C}

        // 4. Mostrar o arquivo gravado com File.ReadAllText
    }
}
