namespace TurtleToast.Service.Core;

/// <summary>
/// Sets the priority of the toast message.
/// Items with a higher priority override the queue of all other toast messages.
/// Todo: Better summarize how the priorty system works.
/// </summary>
public enum Priority
{
    /// <summary>
    /// Low message priority. See <see cref="Priority"/> for more information.
    /// </summary>
    Low = 0,
    /// <summary>
    /// Medium message priority. See <see cref="Priority"/> for more information.
    /// </summary>
    Medium = 1,
    /// <summary>
    /// High message priority. See <see cref="Priority"/> for more information.
    /// </summary>
    High = 2
}
