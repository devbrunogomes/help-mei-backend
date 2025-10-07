using HelpMEI.API.ExceptionHandlers;

namespace HelpMEI.API.Configurations;

public static class ExceptionHandlerExtensions {
	public static IServiceCollection AddExceptionHandlers(this IServiceCollection services) {
		services.AddExceptionHandler<ChainExceptionHandler>();

		return services;
	}
}
