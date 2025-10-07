using Microsoft.AspNetCore.Diagnostics;

namespace HelpMEI.API.ExceptionHandlers;

public class ChainExceptionHandler : IExceptionHandler {
	private readonly IServiceProvider _serviceProvider;

	public ChainExceptionHandler( IServiceProvider serviceProvider) {
		_serviceProvider = serviceProvider;
	}

	public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) {
		using var scope = _serviceProvider.CreateScope();
		var handlers = scope.ServiceProvider.GetServices<ICustomExceptionHandler>()
			 .OrderBy(h => h.Order)
			 .ToArray();

		for (int i = 0; i < handlers.Length - 1; i++) {
			handlers[i].SetNext(handlers[i + 1]);
		}

		Microsoft.AspNetCore.Mvc.ProblemDetails problemDetails = new();
		await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

		return true;
	}
}
