using System;
using TurtleToastService.Service;
using TurtleToastService.Service.Views.Loading;

namespace TurtleToastService.DemoApp.ToastSimulation;

internal static class LoadingSimulation
{
    private const int _loadingMaxCount = 10;

    private static event EventHandler _increaseCountOne;
    private static event EventHandler<int> _increaseCountFive;
    private static event EventHandler _completeToast;

    /// <summary>
    /// Increases the progress count by one.
    /// </summary>
    internal static void IncreaseCountByOne() => _increaseCountOne?.Invoke(null, null);

    /// <summary>
    /// Increases the progress count by five.
    /// </summary>
    internal static void IncreaseCountByFive() => _increaseCountFive?.Invoke(null, 5);

    /// <summary>
    /// Completes the loading toast.
    /// </summary>
    internal static void CompleteToast() => _completeToast?.Invoke(null, null);

    /// <summary>
    /// Displays a counted loading toast.
    /// </summary>
    internal static void LoadingCount()
    {
        var toast = TurtleToast.Loading("Loading count", "count", _loadingMaxCount, displayMode: ProgressDisplayMode.FullCount);
        AssignLoadingEvents(toast);
    }

    /// <summary>
    /// Displays a infinite loading toast.
    /// </summary>
    internal static void LoadingInfinite()
    {
        var toast = TurtleToast.Loading("Loading infinite", "This can take a while", displayMode: ProgressDisplayMode.Count);
        AssignLoadingEvents(toast);
    }

    internal static void AssignLoadingEvents(ILoadingToast toast)
    {
        EventHandler unsubscribeEvents = null;

        _increaseCountOne += toast.IncrementProgress;
        _increaseCountFive += toast.IncrementProgress;
        _completeToast += toast.FinishToast;
        unsubscribeEvents = (s, e) =>
        {
            _increaseCountOne -= toast.IncrementProgress;
            _increaseCountFive -= toast.IncrementProgress;
            _completeToast -= toast.FinishToast;
            toast.Completed -= unsubscribeEvents;
        };

        toast.Completed += unsubscribeEvents;
    }
}
