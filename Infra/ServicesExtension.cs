﻿using Infra.Repositories.CData;
using Infra.Repositories.EntityFramework;
using Infra.Repositories.MongoDbDriver;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class ServicesExtension
	{
		public static IServiceCollection RegisterInfraDependencies(this IServiceCollection services)
		{
			services.AddScoped<IGameCDataRepository, GameCDataRepository>();
			services.AddScoped<IGameEFRepository, GameEFRepository>();
			services.AddScoped<IGameMongoDbDriverRepository, GameMongoDbDriverRepository>();

			services.AddScoped<IPurchaseCDataRepository, PurchaseCDataRepository>();
			services.AddScoped<IPurchaseEFRepository, PurchaseEFRepository>();
			services.AddScoped<IPurchaseMongoDbDriverRepository, PurchaseMongoDbDriverRepository>();

			services.AddScoped<IUserCDataRepository, UserCDataRepository>();
			services.AddScoped<IUserEFRepository, UserEFRepository>();
			services.AddScoped<IUserMongoDbDriverRepository, UserMongoDbDriverRepository>();

			return services;
		}
	}
}
