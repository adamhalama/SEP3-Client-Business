﻿using System;
using System.ComponentModel;

namespace CarRentalClientServer.Data
{
    public class DateTimeConversions
    {

        /*public static long GetUnixTimestampFromString(string dateTime)
        {
            //todo
            return 1;
        }*/
        
        public static long GetUnixTimestampNow()
        {
            TimeSpan timeSpan = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0);

            return (long)timeSpan.TotalSeconds * 1000;
        }

        public static string GetTimeAndDateFormat(long timestamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            
            return dateTime.AddMilliseconds(timestamp).ToString("HH:mm dd/MM/yyyy");
        }
        
    }
}