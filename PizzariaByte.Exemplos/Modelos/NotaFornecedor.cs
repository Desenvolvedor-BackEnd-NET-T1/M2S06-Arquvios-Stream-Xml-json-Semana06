using System.Xml.Serialization;

// Aula 2. A nota que o fornecedor de ingredientes manda em XML.
// O XmlSerializer exige classe pública e um construtor sem
// parâmetros (sem escrever construtor, o C# já cria um).
[XmlRoot("nota")]
public class NotaFornecedor
{
    [XmlAttribute("numero")]
    public int Numero { get; set; }

    [XmlElement("fornecedor")]
    public string Fornecedor { get; set; }

    [XmlArray("itens")]
    [XmlArrayItem("item")]
    public List<ItemNota> Itens { get; set; }
}

public class ItemNota
{
    [XmlAttribute("produto")]
    public string Produto { get; set; }

    [XmlAttribute("quantidade")]
    public int Quantidade { get; set; }

    [XmlAttribute("unidade")]
    public string Unidade { get; set; }
}
