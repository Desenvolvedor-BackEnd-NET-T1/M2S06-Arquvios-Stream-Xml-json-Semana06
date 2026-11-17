using System.Threading.Channels;

// Aula 3. Prática: a fila de entregas.
// O forno coloca as pizzas prontas na fila e o motoboy
// leva uma de cada vez (1,5 s por entrega).
static class C05_Pratica
{
    public static async Task Executar()
    {
        string[] bairros =
            { "Trindade", "Centro", "Pantanal", "Itacorubi" };
        Channel<string> entregas =
            Channel.CreateUnbounded<string>();

        // Produtor: o forno (crie com Task.Run)
        // 1. Para cada bairro, coloque na fila e mostre
        //    Log($"Forno: pizza para {bairro} na fila")
        // 2. Depois do último, avise que não vem mais nada

        // Consumidor: o motoboy (crie com Task.Run)
        // 1. Leia a fila com await foreach
        // 2. Para cada bairro, espere 1,5 s (Task.Delay(1500))
        //    e mostre Log($"Motoboy: entregue em {bairro}")

        // Espere as duas tarefas (Task.WhenAll) e mostre
        // Log("Fim das entregas")
    }
}
