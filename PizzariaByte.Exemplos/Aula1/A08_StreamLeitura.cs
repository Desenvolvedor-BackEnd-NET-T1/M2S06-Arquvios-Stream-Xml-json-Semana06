// Aula 1. StreamReader: lê uma linha de cada vez
static class A08_StreamLeitura
{
    public static void Executar()
    {
        string caminho =
            Path.Combine("dados", "pedidos.log");
        if (!File.Exists(caminho))
        {
            Console.WriteLine("Rode o stream-escrita.");
            return;
        }

        int contador = 0;
        string ultima = "";
        using (StreamReader leitor =
               new StreamReader(caminho))
        {
            // EndOfStream: chegou ao fim do arquivo?
            while (!leitor.EndOfStream)
            {
                string linha = leitor.ReadLine();
                contador++;
                ultima = linha;
            }
        }

        // Só uma linha ficou na memória por vez
        Console.WriteLine($"{contador} linhas lidas");
        Console.WriteLine($"Última: {ultima}");
    }
}
