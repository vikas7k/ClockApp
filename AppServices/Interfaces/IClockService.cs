
namespace AppServices.Interfaces
{
  public  interface IClockService
    {
        string getTimeText(string time);

        string getCurrentTimeText();
    }
}
