using Infra.CData.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CData
{
	public static class ServicesExtension
	{
		public static IServiceCollection RegisterCDataDependencies(this IServiceCollection services)
		{
			services.AddScoped<IGameCDataRepository, GameCDataRepository>();
			services.AddScoped<IPurchaseCDataRepository, PurchaseCDataRepository>();
			services.AddScoped<IUserCDataRepository, UserCDataRepository>();

			return services;
		}
	}
}
