// Aula 3. Queue<T>: o primeiro que entra é o primeiro que sai
static class C02_Queue
{
    public static void Executar()
    {
        Queue<string> fila = new Queue<string>();

        // Enqueue: entra no fim da fila
        fila.Enqueue("1001 · Ana");
        fila.Enqueue("1002 · Bruno");
        fila.Enqueue("1003 · Carla");
        Console.WriteLine($"Na fila: {fila.Count}");

        // Peek: olha o primeiro, sem tirar
        Console.WriteLine($"Próximo: {fila.Peek()}");

        // Dequeue: tira o primeiro da fila
        while (fila.Count > 0)
        {
            string pedido = fila.Dequeue();
            Console.WriteLine($"Preparando {pedido}");
        }
        Console.WriteLine($"Na fila: {fila.Count}");
    }
}
