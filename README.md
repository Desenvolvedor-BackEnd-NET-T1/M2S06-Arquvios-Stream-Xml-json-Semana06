# Pizzaria Byte, semana 06 (M2S06): projeto da turma

Requisitos: .NET 10 SDK. Na aula 3, internet e uma conta gratuita no CloudAMQP.

```
dotnet build PizzariaByte.slnx
```

| Projeto | O que é | Como rodar |
|---|---|---|
| `PizzariaByte.Exemplos` | Exemplos e exercícios das três aulas | `dotnet run -- <exemplo>` |
| `PizzariaByte.Api` | Web API da pizzaria com filas (aula 3) | `dotnet run` (http://localhost:5212/swagger) |
| `PizzariaByte.Cozinha` | A cozinha que lê a fila do RabbitMQ (aula 3) | `dotnet run` |

Rode os exemplos de dentro da pasta `PizzariaByte.Exemplos`. Os arquivos que os
exemplos criam vão para a pasta `dados`. Pelo Visual Studio, ela fica em
`bin\Debug\net10.0`.

## Exercícios (PizzariaByte.Exemplos)

| Aula | Rode com | Arquivo |
|---|---|---|
| 1 | `dotnet run -- pratica1` | Aula1/A05_Pratica.cs |
| 1 | `dotnet run -- pratica2` | Aula1/A11_Pratica.cs |
| 2 | `dotnet run -- pratica3` | Aula2/B05_Pratica.cs |
| 2 | `dotnet run -- pratica4` | Aula2/B09_Pratica.cs |
| 3 | `dotnet run -- pratica5` | Aula3/C05_Pratica.cs |

Os outros exemplos já estão prontos: rode `dotnet run` sem nome para ver a lista.

## Conta no CloudAMQP (antes da aula 3)

1. Crie uma conta gratuita em cloudamqp.com. Na pergunta sobre a GDPR, responda No.
2. Create New Instance: nome `pizzaria-byte`, plano Little Lemur (Free), região
   AWS `sa-east-1` (ou `us-east-1`).
3. Abra a instância e copie a URL de AMQP details (começa com `amqps://`).

Guarde a URL só para você: ela tem a sua senha. Ela vai no User Secrets dos dois
projetos, nunca no código:

```
cd PizzariaByte.Api
dotnet user-secrets set "RabbitMQ:Url" "sua-url"
cd ../PizzariaByte.Cozinha
dotnet user-secrets set "RabbitMQ:Url" "sua-url"
```
