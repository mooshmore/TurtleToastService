using System;
using TurtleToast.Service.Core;
using TurtleToast.Service.ToastStyling;

namespace TurtleToast.DemoApp.ToastSimulation;

internal static class ThemeChangeSimulation
{
    /// <summary>
    /// Changes the toast theme.
    /// </summary>
    internal static void ChangeTheme(ToastTheme theme)
    {
        TurtleToastThemeManager.ChangeTheme(theme);
        TurtleToastService.Default.ClearAll();

        switch (theme)
        {
            case ToastTheme.Light:
                TurtleToastService.Default.Confirmation("Light theme!", "Secondary text!");
                break;
            case ToastTheme.Dark:
                TurtleToastService.Default.Confirmation("Dark theme!", "Secondary text!");
                break;
            case ToastTheme.StoneGrey:
                TurtleToastService.Default.Confirmation("Stone grey theme!", "Secondary text!");
                break;
            case ToastTheme.TurtleGreen:
                TurtleToastService.Default.Confirmation("Turlte green theme!", "Secondary text!");
                break;
        }
    }
}
