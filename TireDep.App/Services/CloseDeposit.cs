using System;

namespace TireDep.App.Services
{
    public static class CloseDeposit
    {
        public static double CalculatePrice(DateTime startDate, DateTime? endDate)
        {
            double dayPrice = Settings.DailyRate;
            var duration = (endDate.Value - startDate).TotalDays;
          
            var totalPrice = Math.Round((duration * dayPrice), 2);
                
            
            return totalPrice;
        }

        public static bool SetIsNoActive(bool isActive)
        {
            isActive = false;
            return isActive;
        }
    }
}