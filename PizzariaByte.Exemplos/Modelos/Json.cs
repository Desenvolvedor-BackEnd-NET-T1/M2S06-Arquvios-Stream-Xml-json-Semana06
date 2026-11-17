using System.Text.Encodings.Web;
using System.Text.Json;

// Aula 2. As opções do JSON, criadas uma vez e reaproveitadas
static class Json
{
    public static readonly JsonSerializerOptions Opcoes =
        new JsonSerializerOptions
        {
            // Com quebras de linha e recuo
            WriteIndented = true,

            // Numero vira "numero" no JSON
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

            // Na leitura, aceita "numero" ou "Numero"
            PropertyNameCaseInsensitive = true,

            // Escreve "João" em vez de "Jo\u00E3o"
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
}
