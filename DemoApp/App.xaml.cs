using CrossUtilitiesWPF.MiscUtilities;
using System.Windows;

namespace TurtleToastService.DemoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Assign viewModels to views
            DataTemplateManager.LoadDataTemplatesByConvention();

            MiscWPFUtilities.SetAutoLinkOpening();
        }
    }
}
