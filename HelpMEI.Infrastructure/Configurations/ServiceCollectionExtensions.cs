using Microsoft.Extensions.DependencyInjection;

namespace HelpMEI.Infrastructure.Configurations;
public static class ServiceCollectionExtensions {
	public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
		return services;
	}
}
