// Aula 1. Arquivo de texto: escrever, acrescentar e ler
static class A03_Texto
{
    public static void Executar()
    {
        Directory.CreateDirectory("dados");
        string caminho = Path.Combine("dados", "aviso.txt");

        // Cria o arquivo (ou apaga o que tinha) e escreve
        File.WriteAllText(caminho, "Hoje tem rodízio!\n");

        // Acrescenta no fim, sem apagar o que já existe
        File.AppendAllText(caminho, "Das 19h às 23h.\n");

        // Lê o arquivo inteiro como um texto só
        string conteudo = File.ReadAllText(caminho);
        Console.Write(conteudo);

        // WriteAllText de novo: o conteúdo antigo some
        File.WriteAllText(caminho, "Rodízio cancelado.\n");
        Console.Write(File.ReadAllText(caminho));
    }
}
