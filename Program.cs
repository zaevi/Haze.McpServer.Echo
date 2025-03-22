using Microsoft.Extensions.AI;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using System.ComponentModel;

var builder = Host.CreateEmptyApplicationBuilder(null);
builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithTools(AIFunctionFactory.Create(EchoTool.Echo));

var app = builder.Build();
await app.RunAsync();

public static class EchoTool
{
    [Description("Echoes the message back to the client.")]
    public static string Echo([Description("message content")] string message) => $"hello {message}";

}