using McpDotNet;
using McpDotNet.Protocol.Types;
using McpDotNet.Server;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;

var builder = Host.CreateEmptyApplicationBuilder(null);
builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithListResourcesHandler((_, _) => Task.FromResult(new ListResourcesResult { Resources = [] }))
    .WithListPromptsHandler((_, _) => Task.FromResult(new ListPromptsResult { Prompts = [] }))
    .WithTools();

var app = builder.Build();
await app.RunAsync();


[McpToolType]
public static class EchoTool
{
    [McpTool, Description("Echoes the message back to the client.")]
    public static string Echo(string message) => $"hello {message}";
}