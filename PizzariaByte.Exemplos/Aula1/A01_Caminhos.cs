// Aula 1. Caminhos: o endereço de um arquivo no disco
static class A01_Caminhos
{
    public static void Executar()
    {
        // A pasta de onde o programa está rodando
        string atual = Directory.GetCurrentDirectory();
        Console.WriteLine($"Pasta atual: {atual}");

        // Path.Combine coloca a barra certa
        // (\ no Windows, / no Linux e no Mac)
        string relativo = Path.Combine("dados", "caixa.txt");
        Console.WriteLine($"Relativo: {relativo}");

        // Relativo + pasta atual = caminho completo
        string completo = Path.GetFullPath(relativo);
        Console.WriteLine($"Completo: {completo}");

        // As partes do caminho
        Console.WriteLine(Path.GetFileName(completo));
        Console.WriteLine(Path.GetExtension(completo));
        Console.WriteLine(
            Path.GetFileNameWithoutExtension(completo));
    }
}
