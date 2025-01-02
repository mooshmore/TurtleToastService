using System;
using TurtleToastService.Service.Core;
using TurtleToastService.Service.ToastStyling;

namespace TurtleToastService.DemoApp.ToastSimulation;

internal static class ThemeChangeSimulation
{
    /// <summary>
    /// Changes the toast theme.
    /// </summary>
    internal static void ChangeTheme(ToastTheme theme)
    {
        TurtleToastThemeManager.ChangeTheme(theme);
        TurtleToastService.Service.Core.TurtleToastService.Default.ClearAll();

        switch (theme)
        {
            case ToastTheme.Light:
                TurtleToastService.Service.Core.TurtleToastService.Default.Confirmation("Light theme!", "Secondary text!");
                break;
            case ToastTheme.Dark:
                TurtleToastService.Service.Core.TurtleToastService.Default.Confirmation("Dark theme!", "Secondary text!");
                break;
            case ToastTheme.StoneGrey:
                TurtleToastService.Service.Core.TurtleToastService.Default.Confirmation("Stone grey theme!", "Secondary text!");
                break;
            case ToastTheme.TurtleGreen:
                TurtleToastService.Service.Core.TurtleToastService.Default.Confirmation("Turlte green theme!", "Secondary text!");
                break;
        }
    }
}
