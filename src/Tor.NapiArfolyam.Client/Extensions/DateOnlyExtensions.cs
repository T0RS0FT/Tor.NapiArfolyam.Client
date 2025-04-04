﻿namespace Tor.NapiArfolyam.Client.Extensions
{
    internal static class DateOnlyExtensions
    {
        internal static string ToNapiArfolyamFormat(this DateOnly date)
            => $"{date.Year:D4}{date.Month:D2}{date.Day:D2}";
    }
}
