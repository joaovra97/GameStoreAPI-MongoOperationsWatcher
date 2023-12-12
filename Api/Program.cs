using Application;
using Infra.CData;
using Infra.EntityFramework;
using Infra.MongoDbDriver;

namespace Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.RegisterApplicationDependencies();
			builder.Services.RegisterMongoDbDriverDependencies();
			builder.Services.RegisterEntityFrameworkDependencies();
			builder.Services.RegisterCDataDependencies();

			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();


			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}