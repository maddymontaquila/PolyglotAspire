using System.Runtime.CompilerServices;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireApp1_ApiService>("apiservice");

builder.AddProject<Projects.AspireApp1_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

var py = builder.AddPythonProject("aspyre", "../PythonApp", "aspyre.py")
   .WithEndpoint(targetPort:8111, env: "PORT", scheme: "http");

var js = builder.AddNpmApp("javascriptapp", "../NodeApp/vue-project", "dev")
    .WithEndpoint(targetPort:5173, env: "JSPORT", scheme: "http", name: "jspoint")
    .WithEnvironment("VITE_BACKEND_URL", apiService.GetEndpoint("https"))
    .WithReference(apiService);

builder.Build().Run();
