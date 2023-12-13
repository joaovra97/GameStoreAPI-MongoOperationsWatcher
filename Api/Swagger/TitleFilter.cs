using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger
{
	public class TitleFilter : IDocumentFilter
	{
		public void Apply(OpenApiDocument doc, DocumentFilterContext context)
		{
			doc.Info.Title = "Game Store API - Mongo Operations Watcher";
		}
	}
}
