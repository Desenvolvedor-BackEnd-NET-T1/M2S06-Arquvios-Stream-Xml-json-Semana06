using System.Xml.Serialization;

// Aula 2. XmlSerializer: o XML do fornecedor vira objeto C#
static class B08_XmlLer
{
    public static void Executar()
    {
        XmlSerializer xml =
            new XmlSerializer(typeof(NotaFornecedor));

        string caminho =
            Path.Combine("entrada", "nota-fornecedor.xml");
        NotaFornecedor nota;
        using (StreamReader arquivo =
               new StreamReader(caminho))
        {
            // Deserialize devolve object: converta com (Tipo)
            nota = (NotaFornecedor)xml.Deserialize(arquivo);
        }

        Console.WriteLine(
            $"Nota {nota.Numero} · {nota.Fornecedor}");
        foreach (ItemNota item in nota.Itens)
            Console.WriteLine(
                $"  {item.Produto}: {item.Quantidade} {item.Unidade}");
    }
}
