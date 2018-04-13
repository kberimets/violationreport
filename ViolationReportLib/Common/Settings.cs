using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViolationReportLib
{
    public static class Settings
    {
        private static int _duration;

        public static DateTime StartTime { get; set; }
        public static DateTime EndTime { get; set; }
        public static int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        static Settings()
        {
            SetDefaultTime();
            _duration = 300;
        }

        private static void SetDefaultTime()
        {
            StartTime = DateTime.Today.AddDays(-1);
            EndTime = DateTime.Now.TimeOfDay.Hours >= 6 ? DateTime.Today.AddHours(6).AddSeconds(-1) : DateTime.Now;
        }
    }
}
