using System;
using System.Collections.Generic;
using System.Text;

namespace Kira.Functional
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan Milliseconds(this int @this)
          => TimeSpan.FromMilliseconds(@this);

        public static TimeSpan Seconds(this int @this)
            => TimeSpan.FromSeconds(@this);

        public static TimeSpan Minutes(this int @this)
            => TimeSpan.FromMinutes(@this);

        public static TimeSpan Days(this int @this)
            => TimeSpan.FromDays(@this);

        public static DateTime Ago(this TimeSpan @this)
            => DateTime.UtcNow - @this;
    }
}
