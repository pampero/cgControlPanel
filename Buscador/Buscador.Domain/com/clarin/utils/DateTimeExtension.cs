using System;


namespace Buscador.Domain.com.clarin.utils
{

    public static class DateTimeExtension
    {
        public static DateTime TruncateToSeconds(this DateTime source)
        {
            return new DateTime(source.Ticks - (source.Ticks % TimeSpan.TicksPerSecond), source.Kind);
        }
    }
}

