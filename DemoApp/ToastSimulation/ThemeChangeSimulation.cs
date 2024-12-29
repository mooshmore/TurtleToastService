using System;
using TurtleToastService.Service;
using TurtleToastService.Service.ToastStyling;

namespace TurtleToastService.DemoApp.ToastSimulation;

internal static class ThemeChangeSimulation
{
    /// <summary>
    /// Changes the toast theme.
    /// </summary>
    internal static void ChangeTheme(ToastTheme theme)
    {
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
