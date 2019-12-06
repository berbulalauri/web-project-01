using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_01.Models;

namespace practice_01.Services
{
    public class CurrentTimeService : ITimeService
    {
        public CurrentTimeService()
        {
        }
        public string GetTime()
        {
            var timeList = new List<Times>
            {
                new Times(DateTime.Now.Hour.ToString(),DateTime.Now.Minute.ToString(),DateTime.Now.Second.ToString())
            };
            var now = timeList[0];

            return $"Hour: {now.Hour}\nMinute: {now.Minute}\nSecond: {now.Second}";
        }

    }
}

//new Times { Hour = $"Hour: {DateTime.Now.Hour.ToString()}" },
//new Times { Minute = $"Minute: {DateTime.Now.Minute.ToString()}" },
//new Times { Second = $"Second: {DateTime.Now.Second.ToString()}" }
