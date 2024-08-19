namespace KilimoWebApp.Common;

public record ResponseBody(int status, string message, object data);