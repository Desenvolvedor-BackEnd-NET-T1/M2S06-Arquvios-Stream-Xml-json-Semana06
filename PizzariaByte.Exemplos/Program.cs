// Escolha o exemplo pelo nome: dotnet run -- caminhos
// Sem nome, mostra a lista.
// Os arquivos gerados ficam na pasta "dados", e os que os
// exemplos leem prontos ficam na pasta "entrada".
using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8; // acentos no terminal
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR"); // R$ 45,90
CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

var exemplos = new Dictionary<string, Func<Task>>
{
    // Aula 1: arquivos e pastas com System.IO
    ["caminhos"] = Rodar(A01_Caminhos.Executar),
    ["pastas"] = Rodar(A02_Pastas.Executar),
    ["texto"] = Rodar(A03_Texto.Executar),
    ["linhas"] = Rodar(A04_Linhas.Executar),
    ["pratica1"] = Rodar(A05_Pratica.Executar),
    ["gerenciar"] = Rodar(A06_Gerenciar.Executar),
    ["stream-escrita"] = Rodar(A07_StreamEscrita.Executar),
    ["stream-leitura"] = Rodar(A08_StreamLeitura.Executar),
    ["csv-gravar"] = Rodar(A09_CsvGravar.Executar),
    ["csv-ler"] = Rodar(A10_CsvLer.Executar),
    ["pratica2"] = Rodar(A11_Pratica.Executar),

    // Aula 2: serialização com JSON e XML
    ["serializar"] = Rodar(B01_Serializar.Executar),
    ["desserializar"] = Rodar(B02_Desserializar.Executar),
    ["opcoes"] = Rodar(B03_Opcoes.Executar),
    ["atributos"] = Rodar(B04_Atributos.Executar),
    ["pratica3"] = Rodar(B05_Pratica.Executar),
    ["json-stream"] = B06_JsonStream.Executar,
    ["xml-gravar"] = Rodar(B07_XmlGravar.Executar),
    ["xml-ler"] = Rodar(B08_XmlLer.Executar),
    ["pratica4"] = Rodar(B09_Pratica.Executar),

    // Aula 3: filas
    ["sem-fila"] = C01_SemFila.Executar,
    ["queue"] = Rodar(C02_Queue.Executar),
    ["channel"] = C03_Channel.Executar,
    ["dois-pizzaiolos"] = C04_DoisPizzaiolos.Executar,
    ["pratica5"] = C05_Pratica.Executar,
};

if (args.Length == 0 || !exemplos.ContainsKey(args[0]))
{
    Console.WriteLine("Use: dotnet run -- <exemplo>");
    foreach (string nome in exemplos.Keys)
        Console.WriteLine("  " + nome);
    return;
}

Ferramentas.Relogio.Restart();
await exemplos[args[0]]();

// Transforma um exemplo síncrono (void) em Task, para caber no dicionário
static Func<Task> Rodar(Action exemplo)
{
    return () =>
    {
        exemplo();
        return Task.CompletedTask;
    };
}
