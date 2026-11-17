using System.Xml.Serialization;

// Aula 2. XmlSerializer: objeto C# vira XML
static class B07_XmlGravar
{
    public static void Executar()
    {
        NotaFornecedor nota = new NotaFornecedor
        {
            Numero = 5520,
            Fornecedor = "Laticínios Serra Azul",
            Itens = new List<ItemNota>
            {
                new ItemNota { Produto = "Mussarela",
                    Quantidade = 10, Unidade = "kg" },
                new ItemNota { Produto = "Parmesão",
                    Quantidade = 2, Unidade = "kg" }
            }
        };

        // Um XmlSerializer para cada tipo de classe
        XmlSerializer xml =
            new XmlSerializer(typeof(NotaFornecedor));

        // Sem os xmlns automáticos no cabeçalho
        var semNamespace = new XmlSerializerNamespaces();
        semNamespace.Add("", "");

        Directory.CreateDirectory("dados");
        string caminho = Path.Combine("dados", "nota.xml");
        using (StreamWriter arquivo =
               new StreamWriter(caminho))
        {
            xml.Serialize(arquivo, nota, semNamespace);
        }
        Console.WriteLine(File.ReadAllText(caminho));
    }
}
