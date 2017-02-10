using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace SplitFile
{
    class Time
    {
        public static string time;
        public Time()
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-GB");
            time = localDate.ToString(culture).Trim();
        }
        public string Get_Day()
        {
            string str = time.Substring(0, 2);
            return str;
        }
        public string Get_Month()
        {
            string str = time.Substring(3,2);
            return str;
        }
        public string Get_Year()
        {
            string str = time.Substring(6, 4);
            return str;
        }

        public string Get_Hour()
        {
            string str = time.Substring(11, 2);
            return str;
        }

        public string Get_Minute()
        {
            string str = time.Substring(14, 2);
            return str;
        }

        public string Get_Second()
        {
            string str = time.Substring(17, 2);
            return str;
        }

        public string Get_DayNameLog()
        {
            string str = Get_Year() + Get_Month() + Get_Day();
            return str;
        }

        public string Get_TimeNameLog()
        {
            string str = Get_Hour() + Get_Minute();
            return str;
        }

        public string Get_DateNameTimeLog()
        {
            string str = Get_DayNameLog() + Get_TimeNameLog();
            return str;
        }

        public string Get_TimeLog()
        {
            string str = Get_Year() + "/" + Get_Month() + "/" + Get_Day() + " " + Get_Hour() + ":" + Get_Minute() + ":" + Get_Second();
            return str;
        }
    }
}
