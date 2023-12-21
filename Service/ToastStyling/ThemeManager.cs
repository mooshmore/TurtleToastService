using System;
using System.Windows;

namespace TurtleToastService.Service.ToastStyling
{
    /// <summary>
    /// A class responsible for controlling the theme of the service.
    /// </summary>
    public static class ThemeManager
    {
        /// <summary>
        /// Changes the theme to the chosen one and sets the <see cref="ActiveTheme"/>.
        /// </summary>
        /// <param name="theme">The theme to change to. See <see cref="ToastTheme"/> for the list of avaialable themes.</param>
        public static void ChangeTheme(ToastTheme theme)
        {
            Uri uri = new Uri($"/TurtleToastService.Service;component/ToastStyling/Themes/{theme}.xaml", UriKind.Relative);
            var themeDictionary = new ResourceDictionary() { Source = uri };
            ActiveTheme = theme;
            ThemeChanged.Invoke(null, themeDictionary);
        }

        /// <summary>
        /// The currently active theme.
        /// </summary>
        public static ToastTheme ActiveTheme { get; set; }

        /// <summary>
        /// A event that is raised then the <see cref="ActiveTheme"/> is changed.
        /// </summary>
        public static EventHandler<ResourceDictionary> ThemeChanged { get; set; }
    }

    /// <summary>
    /// Holds the available themes.
    /// </summary>
    public enum ToastTheme
    {
        Light,
        Dark,
        StoneGrey,
        TurtleGreen,
    }
}
