namespace BlazorApp.AppCore.Utilities;

public class DateBuilder
{
    public static string ConvertSecondsToDateString(double seconds)
    {
        TimeSpan t = TimeSpan.FromSeconds(seconds);
        return string.Format("{0:D2}h {1:D2}m {2:D2}s", t.Hours, t.Minutes, t.Seconds);
    }
}
