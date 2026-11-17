using System.Diagnostics;

// Ferramentas usadas pelos exemplos da semana.
static class Ferramentas
{
    // Cronômetro: o tempo desde o início do exemplo
    public static readonly Stopwatch Relogio = new Stopwatch();

    // Escreve assim: 3,0s texto
    public static void Log(string texto)
    {
        double s = Relogio.Elapsed.TotalSeconds;
        Console.WriteLine($"{s:0.0}s {texto}");
    }
}
