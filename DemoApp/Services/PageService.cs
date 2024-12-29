using System;
using System.Windows;
using Wpf.Ui;

namespace TurtleToastService.DemoApp.Services;

/// <summary>
/// Service that provides pages for navigation.
/// </summary>
public class PageService(IServiceProvider serviceProvider) : IPageService
{
    /// <inheritdoc cref="IPageService.GetPage{T}()" />
    public T? GetPage<T>()
        where T : class
    {
        if (!typeof(FrameworkElement).IsAssignableFrom(typeof(T)))
            throw new InvalidOperationException("The page should be a WPF control.");

        return (T?)serviceProvider.GetService(typeof(T));
    }

    /// <inheritdoc cref="IPageService.GetPage(Type)" />
    public FrameworkElement? GetPage(Type pageType)
    {
        if (!typeof(FrameworkElement).IsAssignableFrom(pageType))
            throw new InvalidOperationException("The page should be a WPF control.");

        return serviceProvider.GetService(pageType) as FrameworkElement;
    }
}
