
namespace AppServices.Interfaces
{
    public interface IValidationService
    {
        bool IsTimeValid(string time, out string message);
    }
}
