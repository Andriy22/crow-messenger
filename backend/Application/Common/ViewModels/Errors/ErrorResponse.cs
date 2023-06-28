namespace Application.Common.ViewModels.Errors;

public record ErrorResponse(int Code, string Error, string? Stacktrace);