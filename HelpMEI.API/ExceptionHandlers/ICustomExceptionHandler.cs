using Microsoft.AspNetCore.Mvc;

namespace HelpMEI.API.ExceptionHandlers;

public interface ICustomExceptionHandler {
	int Order { get; }
	Task<ProblemDetails> HandleExceptionAsync(Exception exception, HttpContext context);
	ICustomExceptionHandler SetNext(ICustomExceptionHandler handler);
}
