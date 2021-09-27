using AppServices.Interfaces;

namespace AppServices
{
    /// <summary>
    /// This service validates user input is in correct time format
    /// </summary>
    public class ValidationService : IValidationService
    {
        private const int maxHours = 23;
        private const int minHours = 0;
        private const int maxMinutes = 59;
        private const int minMinutes = 0;

        /// <summary>
        /// To validate user input is in correct time format
        /// </summary>
        /// <param name="time">Input Time</param>
        /// <param name="message">Validation Message</param>
        /// <returns></returns>
        public bool IsTimeValid(string time, out string message)
        {
            message = string.Empty;

            if (string.IsNullOrWhiteSpace(time) || !time.Contains(":") || time.Split(":").Length < 2) {
                message = "Invalid Time Format- Use HH:MM";
                return false;
            }
            else
            {
                var value = time.Split(":");
                
                int hours, minutes;

                if (!int.TryParse(value[0], out hours)){
                    message = "Invalid Hours";
                    return false;
                }
                else if(hours > maxHours || hours < minHours) {
                    message = $"Hours out of range of {minHours} to {maxHours}";
                    return false;
                };

                if (!int.TryParse(value[1], out minutes)) {
                    message = "Invalid Minutes";
                    return false;
                }
                else if(minutes > maxMinutes || minutes < minMinutes){
                    message = $"Minutes out of range of {minMinutes} to {maxMinutes}";
                    return false;
                };
            }

            return true;
        }
    }
}
