using System.Text.Json;
using System.Xml.Serialization;

// Aula 2. Prática: a nota do fornecedor (XML) entra no
// estoque da pizzaria (JSON)
static class B09_Pratica
{
    static readonly string CaminhoEstoque =
        Path.Combine("dados", "estoque.json");

    public static void Executar()
    {
        // 1. Ler a nota entrada/nota-fornecedor.xml com o
        //    XmlSerializer (como no xml-ler)

        // 2. Carregar o estoque de dados/estoque.json em um
        //    Dictionary<string, int>. Se o arquivo não existe,
        //    comece com um dicionário vazio.

        // 3. Somar a quantidade de cada item da nota no estoque
        //    (se o produto não existe, comece com 0)

        // 4. Gravar o estoque em JSON com Json.Opcoes e mostrar
        //    o texto
    }
}
