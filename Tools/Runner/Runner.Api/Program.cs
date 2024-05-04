using Runner.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddWorkflowDSL();
builder.Services.AddWorkflow();

var app = builder.Build();

app.UseWorkflowHost();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Workflows}/{action=Execute}");

app.Run();
