using System.Threading.Channels;

// Aula 3. Channel<T>: uma fila segura para várias tarefas,
// em que o consumidor espera (await) o próximo pedido
static class C03_Channel
{
    public static async Task Executar()
    {
        Channel<string> fila =
            Channel.CreateUnbounded<string>();
        string[] clientes = { "Ana", "Bruno", "Carla" };

        // Produtor: o atendente anota e volta para o balcão
        Task atendente = Task.Run(async () =>
        {
            foreach (string c in clientes)
            {
                await fila.Writer.WriteAsync(c);
                Log($"Atendente: pedido de {c} na fila");
            }
            fila.Writer.Complete(); // não vem mais pedido
        });

        // Consumidor: o pizzaiolo pega um pedido por vez
        Task pizzaiolo = Task.Run(async () =>
        {
            var leitura = fila.Reader.ReadAllAsync();
            await foreach (string c in leitura)
            {
                await Task.Delay(2000);
                Log($"Pizzaiolo: pizza de {c} pronta");
            }
        });

        await Task.WhenAll(atendente, pizzaiolo);
    }
}
