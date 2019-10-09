using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace NalogUser.Classes
{
    public class TimeWatcher
    {
        private Stopwatch sWatch;
        //
        public TimeWatcher()
        {
            sWatch=new Stopwatch();
            sWatch.Start();
        }
        //
        private string leftSeconds;
        private string leftMinutes;
        private string leftHours;
        private string leftDays;
        private string leftWeeks;
        private string leftMonths;
        private string leftYears;
        //
        public string LeftSeconds { get { leftSeconds = (sWatch.ElapsedMilliseconds / 100).ToString(); return leftSeconds; } }
        public string LeftMinutes { get {leftMinutes = (sWatch.ElapsedMilliseconds / 100 / 60).ToString(); return leftMinutes; } }
        public string LeftHours { get {leftHours = (sWatch.ElapsedMilliseconds / 100 / 60 / 60).ToString(); return leftHours; } }
        public string LeftDays { get { leftDays = (sWatch.ElapsedMilliseconds / 100 / 60 / 60 / 24).ToString(); return leftDays; } }
        //
        public void StopTimer()
        {
            sWatch.Start();
        }
        public void StartTimer()
        {
            sWatch.Stop();
        }

    }
}
