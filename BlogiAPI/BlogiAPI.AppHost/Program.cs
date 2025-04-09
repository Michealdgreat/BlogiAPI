var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BlogiAPI>("bloggi-api");

builder.Build().Run();
