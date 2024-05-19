using TurtleToastService.Service;
using TurtleToastService.Service.ToastStyling;

namespace TurtleToastService.DemoApp.ToastSimulation
{
    internal class ThemeChangeSimulation
    {
        /// <summary>
        /// Changes the toast theme.
        /// </summary>
        /// <param name="theme">The <see cref="ToastTheme"/> to change to.</param>
        internal static void ChangeTheme(object obj)
        {
            ToastTheme theme = (ToastTheme)obj;
            TurtleToast.ChangeTheme(theme);
            TurtleToast.ClearAll();

            switch (theme)
            {
                case ToastTheme.Light:
                    TurtleToast.Confirmation("Light theme!", "Secondary text!");
                    break;
                case ToastTheme.Dark:
                    TurtleToast.Confirmation("Dark theme!", "Secondary text!");
                    break;
                case ToastTheme.StoneGrey:
                    TurtleToast.Confirmation("Stone grey theme!", "Secondary text!");
                    break;
                case ToastTheme.TurtleGreen:
                    TurtleToast.Confirmation("Turlte green theme!", "Secondary text!");
                    break;
            }
        }
    }
}
