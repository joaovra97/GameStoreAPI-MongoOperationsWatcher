using Infra.Data.Repositories;
using Infra.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data
{
	public static class ServicesExtension
	{
		public static IServiceCollection RegisterInfraDependencies(this IServiceCollection services)
		{
			services.AddScoped<IGameRepository, GameRepository>();
			services.AddScoped<IPurchaseRepository, PurchaseRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			return services;
		}
	}
}
