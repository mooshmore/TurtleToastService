using System;

namespace TurtleToast.Service.Views.Loading;

/// <summary>
/// A interface for the <see cref="LoadingToastViewModel"/>.
/// </summary>
public interface ILoadingToast
{
    /// <summary>
    /// A event that is raised when the toast completes it's display.
    /// </summary>
    public EventHandler? Completed { get; set; }

    /// <summary>
    /// Increments the progress value.
    /// </summary>
    /// <param name="incrementValue">The value to increment by.</param>
    public void IncrementProgress(int incrementValue = 1);

    /// <summary>
    /// Increments the progress by 1.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="args">Unused.</param>
    public void IncrementProgress(object sender, EventArgs args);

    /// <summary>
    /// Increments the progress by a specified amount.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="incrementValue">The amount by which to increment the progress.</param>
    public void IncrementProgress(object sender, int incrementValue);

    /// <summary>
    /// Displays the succes message and completes toast display.
    /// </summary>
    /// <param name="displaySuccesMessage">Whether to display the succes message or not.</param>
    public void FinishToast(bool displaySuccesMessage = true);

    /// <summary>
    /// Completes the toast display.
    /// </summary>
    public void FinishToast(object sender, EventArgs args) => FinishToast(true);

    /// <summary>
    /// Displays the succes message and completes toast display.
    /// </summary>
    /// <param name="displaySuccesMessage">Whether to display the succes message or not.</param>
    public void FinishToast(object sender, bool displaySuccesMessage) => FinishToast(displaySuccesMessage);
}