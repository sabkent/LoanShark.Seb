using System;

namespace LoanShark.Core
{
    public static class TimeSource
    {
        public static Func<DateTime> Source = () => DateTime.Now;

        public static DateTime Now
        {
            get { return Source(); }
        }
    }
}
