using System;

namespace CarRentalClientServer.Utilities
{
    public static class TimeConversionUtility
    {
        public static long GetUnixTimestampNow()
        {
            TimeSpan timeSpan = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0);

            return (long)timeSpan.TotalSeconds * 1000;
        }
        
        public static long DateTimeToUnix(DateTime dateTime)
        {
            TimeSpan timeSpan = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);

            return (long)timeSpan.TotalSeconds * 1000;
        }

        public static DateTime GetDateTime(long timestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dateTime.AddMilliseconds(timestamp);
        }

        public static string GetDateTimeFormat(long timestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            
            return dateTime.AddMilliseconds(timestamp).ToString("HH:mm dd-MM-yyyy");
        }
        
        public static string GetDateFormat(long timestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            
            return dateTime.AddMilliseconds(timestamp).ToString("dd-MM-yyyy");
        }
        
    }
}