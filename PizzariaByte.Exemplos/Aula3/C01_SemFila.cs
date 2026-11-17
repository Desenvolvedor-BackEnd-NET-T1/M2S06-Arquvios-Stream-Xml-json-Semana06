// Aula 3. Sem fila: o cliente espera a cozinha inteira
static class C01_SemFila
{
    public static async Task Executar()
    {
        string[] clientes = { "Ana", "Bruno", "Carla" };
        foreach (string cliente in clientes)
        {
            Log($"{cliente} pediu e espera no balcão");

            // O atendente só volta quando a pizza fica pronta
            await PrepararPizza();

            Log($"{cliente} recebeu a pizza");
        }
    }

    // O forno leva 2 segundos (de mentira) por pizza
    static async Task PrepararPizza()
    {
        await Task.Delay(2000);
    }
}
