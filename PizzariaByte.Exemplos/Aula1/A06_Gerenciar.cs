// Aula 1. Conferir, copiar, mover e apagar arquivos
static class A06_Gerenciar
{
    public static void Executar()
    {
        string caixa = Path.Combine("dados", "caixa.txt");

        // Ler arquivo que não existe dá erro
        if (!File.Exists(caixa))
        {
            Console.WriteLine("Rode a pratica1 antes.");
            return;
        }

        // Informações sobre o arquivo
        FileInfo info = new FileInfo(caixa);
        Console.WriteLine(
            $"{info.Name}: {info.Length} bytes");

        // Copiar (true: substitui a cópia antiga)
        string backup = Path.Combine("dados", "backup");
        Directory.CreateDirectory(backup);
        File.Copy(caixa,
            Path.Combine(backup, "caixa.txt"), true);

        // Mover. Também serve para renomear.
        string fechado =
            Path.Combine("dados", "caixa-fechado.txt");
        File.Move(caixa, fechado, true);
        Console.WriteLine(File.Exists(caixa));
        Console.WriteLine(File.Exists(fechado));

        // Apagar
        File.Delete(fechado);
        Console.WriteLine("Caixa fechado.");
    }
}
