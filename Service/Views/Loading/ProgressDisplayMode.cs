namespace TurtleToastService.Service.Views.Loading
{
    /// <summary>
    /// The format in which the progress will be displayed.
    /// </summary>
    public enum ProgressDisplayMode
    {
        /// <summary>
        /// No progress is displayed.
        /// </summary>
        None = 0,
        /// <summary>
        /// The current progress count is displayed, ex : "Performing operation 56".
        /// </summary>
        Count = 1,
        /// <summary>
        /// The total count of operations is displayed, ex : "Performing operations: 100"
        /// </summary>
        OperationsCount = 2,
        /// <summary>
        /// The current progress count and total count is displayed, ex: "Performing operation 56 of 100"
        /// </summary>
        FullCount = 3,
        /// <summary>
        /// The progress percentage is displayed, ex: "Performing operations (56%)"
        /// </summary>
        Percentage = 4,
        /// <summary>
        /// The full count and percentage is displayed, ex: "Performing operation 56 of 100 (56%)"
        /// </summary>
        CountAndPercentage = 5
    }
}
