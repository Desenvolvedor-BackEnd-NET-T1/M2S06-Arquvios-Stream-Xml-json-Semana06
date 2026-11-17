// Aula 1. Pastas (diretórios): criar, conferir e listar
static class A02_Pastas
{
    public static void Executar()
    {
        // Cria a pasta. Se já existir, não faz nada.
        Directory.CreateDirectory("dados");
        Console.WriteLine(Directory.Exists("dados"));
        Console.WriteLine(Directory.Exists("fotos"));

        // Todos os arquivos de uma pasta
        string[] arquivos = Directory.GetFiles("entrada");
        foreach (string arquivo in arquivos)
            Console.WriteLine(arquivo);

        // Só os que terminam em .csv
        string[] planilhas =
            Directory.GetFiles("entrada", "*.csv");
        Console.WriteLine($"Planilhas: {planilhas.Length}");

        // Cria as pastas do caminho que ainda não existem
        Directory.CreateDirectory(
            Path.Combine("dados", "backup", "2026"));
        foreach (string pasta in
                 Directory.GetDirectories("dados"))
            Console.WriteLine("Pasta: " + pasta);
    }
}
