var builder = DistributedApplication.CreateBuilder(args);

var ollama = builder.AddOllama("ollama").WithDataVolume();
ollama.AddModel("icmchat", "qwen2.5:0.5b");


builder.AddContainer("open-webui", "ghcr.io/open-webui/open-webui", "main")
    .WithHttpEndpoint(port: 3000, targetPort: 8080, name: "http")
    .WithEnvironment("OLLAMA_BASE_URL", ollama.GetEndpoint("http"))
    .WithLifetime(ContainerLifetime.Persistent)
    .WaitFor(ollama);

builder.AddProject<Projects.ICMChat_API>("icmchat-api");

builder.Build().Run();
