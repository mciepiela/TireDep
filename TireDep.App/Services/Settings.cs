using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace TireDep.App.Services
{
    public static class Settings
    {
        public static double DailyRate = 25;

        public static double SetDailyRate(double value)
        {
            DailyRate = value;
            return DailyRate;
        }
    }
}
