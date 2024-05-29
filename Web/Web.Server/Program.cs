using Microsoft.EntityFrameworkCore;
using Web.Backend.Swagger;
using Hangfire;
using Hangfire.PostgreSql;
using Persistense;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		builder.Services.AddLogging();
		builder.Services.AddSwaggerGen(c => c.DocumentFilter<ModelsSchemasFilter>());
		builder.Services.AddPersistense(builder.Configuration);
		builder.Services.AddHangfire(configuration => configuration
			.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
			.UseSimpleAssemblyNameTypeSerializer()
			.UseRecommendedSerializerSettings()
			.UsePostgreSqlStorage(options => options.
				UseNpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))));
		builder.Services.AddHangfireServer();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseHangfireDashboard();
		}
		app.MapSwagger();
		app.MapHangfireDashboard();
		app.MapControllers();


		app.Run();
	}
}