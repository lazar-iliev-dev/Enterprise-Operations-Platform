using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

var builder = DistributedApplication.CreateBuilder(args);

// PostgreSQL-Server Ressource
var postgres = builder.AddPostgres("postgres-server");

// Two separate databases
var taskDb = postgres.AddDatabase("taskdb");
var knowledgeDb = postgres.AddDatabase("knowledgedb");

// Task-Service – Path relative to the AppHost project:
// AppHost:      src/AppHost/
// Api.csproj:   src/Services/TaskService/SmartTaskAPI/src/Api/Api.csproj
// Relativ:      ../Services/TaskService/SmartTaskAPI/src/Api/Api.csproj
var taskService = builder.AddProject(
        "task-service",
        "../Services/TaskService/SmartTaskAPI/src/Api/Api.csproj")
    .WithReference(taskDb)
    .WithExternalHttpEndpoints();

// Knowledge-Service 
var knowledgeService = builder.AddProject(
        "knowledge-service",
        "../Services/KnowledgeService/backend/KnowledgeDatabase.csproj")
    .WithReference(knowledgeDb)
    .WithExternalHttpEndpoints();

// Gateway Service
var gateway = builder.AddProject(
        "gateway",
        "../Services/Gateway/Gateway.csproj")
    .WithExternalHttpEndpoints();

builder.Build().Run();
