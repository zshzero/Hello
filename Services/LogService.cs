using Microsoft.Extensions.Logging;

namespace Hello.Services
{
    public class LogService : ILogService
    {
        public readonly ILogger<LogService> _logger;
        public LogService(ILogger<LogService> logger)
        {
            _logger = logger;
        }
        public void SaveRequest(string FirstName, string LastName, string Reason)
        {
            // Log the Request
            _logger.LogInformation($"Hi, This is {FirstName} {LastName} and {Reason}");
        }
    }
}