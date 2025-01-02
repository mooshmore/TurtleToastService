using System;
using System.Timers;

namespace TurtleToast.Service.Core;

/// <summary>
/// A collection of helper methods for the <see cref="TurtleToastService"/>.
/// </summary>
public class ToastHelpers
{
    /// <summary>
    /// Calculates display time based on the amount of words in the string.
    /// The minimal amount of time is 3 seconds, and the max display is 20 seconds.
    /// </summary>
    /// <remarks>
    /// The maximum display time exists as a failsafe in cases where there will be a extremely long text placed,
    /// mostly due to some kind of a bug with the given text.
    /// </remarks>
    /// <returns>The calculated time in seconds.</returns>
    public static TimeSpan CalculateDisplayTime(string text)
    {
        int wordCount = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        // Calculate seconds - word count per 2 words per second
        double seconds = Math.Ceiling((double)wordCount / 2);

        // Minimal display time is set to 3 seconds
        // Max display time is set to 20 seconds
        if (seconds < 3)
            seconds = 3;
        else if (seconds > 20)
            seconds = 20;

        return TimeSpan.FromSeconds(seconds);
    }

    /// <summary>
    /// Creates a timer with the timeSpan based on the <paramref name="message"/>,
    /// and assigns the Elapsed event to invocation of the <paramref name="eventHandler"/>.
    /// </summary>
    /// <param name="eventHandler">The event handler to invocate</param>
    /// <param name="message">The message to calculate the timeSpan of.</param>
    /// <returns>The created timer.</returns>
    public static Timer CreateTimer(EventHandler eventHandler, string message)
    {
        Timer timer = new()
        {
            Interval = CalculateDisplayTime(message).TotalMilliseconds,
            AutoReset = false,
        };
        timer.Elapsed += eventHandler.Invoke;
        return timer;
    }
}
