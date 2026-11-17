using System.Threading.Channels;

// Aula 3. Dois consumidores na mesma fila: cada pedido vai
// para um pizzaiolo só, e o trabalho termina na metade do tempo
static class C04_DoisPizzaiolos
{
    public static async Task Executar()
    {
        Channel<int> fila = Channel.CreateUnbounded<int>();
        for (int n = 1001; n <= 1006; n++)
            await fila.Writer.WriteAsync(n);
        fila.Writer.Complete();
        Log("6 pedidos na fila");

        Task joao = Pizzaiolo("João", fila.Reader);
        Task maria = Pizzaiolo("Maria", fila.Reader);
        await Task.WhenAll(joao, maria);
        Log("Todos os pedidos prontos");
    }

    static async Task Pizzaiolo(string nome,
                                ChannelReader<int> fila)
    {
        await foreach (int pedido in fila.ReadAllAsync())
        {
            await Task.Delay(2000);
            Log($"{nome}: pedido {pedido} pronto");
        }
    }
}
