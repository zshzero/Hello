namespace Hello.Services
{
public interface ILogService
    {
        void SaveRequest(string FirstName, string LastName, string Reason);
    }
}