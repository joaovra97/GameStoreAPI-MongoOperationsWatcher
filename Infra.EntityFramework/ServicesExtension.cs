using Infra.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.EntityFramework
{
	public static class ServicesExtension
	{
		public static IServiceCollection RegisterEntityFrameworkDependencies(this IServiceCollection services)
		{
			services.AddScoped<IGameEFRepository, GameEFRepository>();
			services.AddScoped<IPurchaseEFRepository, PurchaseEFRepository>();
			services.AddScoped<IUserEFRepository, UserEFRepository>();

			return services;
		}
	}
}
