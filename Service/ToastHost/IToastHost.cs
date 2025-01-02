using TurtleToast.Service.Core;

namespace TurtleToast.Service.ToastHost;

/// <summary>
/// A interface for viewModels hosting the toasts.
/// </summary>
public interface IToastHost
{
    /// <summary>
    /// Displays the given toast message.
    /// </summary>
    void HostToast(IToast toast);

    /// <summary>
    /// Vacates the given toast message.
    /// </summary>
    void VacateToast(IToast toast);
}
