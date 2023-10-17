using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
        .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();
// Add services to the container.
//Register Ocelot
builder.Services.AddOcelot(builder.Configuration);

// Start Add Swagger
builder.Services.AddMvcCore();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

// End Add Swagger

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerForOcelotUI();
await app.UseOcelot();

app.Run();
