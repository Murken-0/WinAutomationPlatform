using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Domain;

namespace Web.Backend.Swagger;

public class ModelsSchemasFilter : IDocumentFilter
{
	public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
	{
		context.SchemaGenerator.GenerateSchema(typeof(Job), context.SchemaRepository);
		context.SchemaGenerator.GenerateSchema(typeof(Workflow), context.SchemaRepository);		
	}
}
