using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServicesExtension
	{
		public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
		{
			services.AddScoped<IGameStorageService, GameStorageService>();
			services.AddScoped<IAutoFakerFacadeService, AutoFakerFacadeService>();
			return services;
		}
	}
}
