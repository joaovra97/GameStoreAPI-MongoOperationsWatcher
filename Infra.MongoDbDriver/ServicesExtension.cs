using Infra.MongoDbDriver.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.MongoDbDriver
{
	public static class ServicesExtension
	{
		public static IServiceCollection RegisterMongoDbDriverDependencies(this IServiceCollection services)
		{
			services.AddScoped<IGameMongoDbDriverRepository, GameMongoDbDriverRepository>();
			services.AddScoped<IPurchaseMongoDbDriverRepository, PurchaseMongoDbDriverRepository>();
			services.AddScoped<IUserMongoDbDriverRepository, UserMongoDbDriverRepository>();

			return services;
		}
	}
}
