using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace TurtleToastService.Service.Utilities.WPF.Converters
{
    /// <summary>
    /// The management class for automatic loading data templates
    /// </summary>
    public static class DataTemplateManager
    {
        /// <summary>
        /// String value added after the name of a view model object (Default is 'ViewModel').
        /// </summary>
        private static string ViewModelNameSuffix { get; set; } = "ViewModel";

        /// <summary>
        /// String value added after the name of a view (Default is 'View').
        /// </summary>
        private static string ViewNameSuffix { get; set; } = "View";

        /// <summary>
        /// Load assembly object and register data templates based on naming convention, e.g., FooViewModel --> FooView
        /// </summary>
        public static void LoadDataTemplatesByConvention()
        {
            var assembly = Assembly.GetCallingAssembly();
            var assemblyTypes = assembly.GetTypes();

            var viewModels = assemblyTypes.Where(x => x.Name.Contains(ViewModelNameSuffix));

            foreach (var vm in viewModels)
            {
                var baseName = vm.Name.Replace(ViewModelNameSuffix, string.Empty);

                var viewType = assemblyTypes.FirstOrDefault(x => x.Name == baseName + ViewNameSuffix);

                if (viewType != null)
                    RegisterDataTemplate(vm, viewType);
            }
        }

        /// <summary>
        /// Register a data template
        /// </summary>
        /// <typeparam name="VM">ViewModel type</typeparam>
        /// <typeparam name="V">View Type</typeparam>
        public static void RegisterDataTemplate<VM, V>()
        {
            var template = CreateTemplate(typeof(VM), typeof(V));
            Application.Current.Resources.Add(template.DataTemplateKey, template);
        }

        /// <summary>
        /// Register a data template
        /// </summary>
        /// <param name="viewModel">ViewModel type</param>
        /// <param name="view">View Type</param>
        private static void RegisterDataTemplate(Type viewModel, Type view)
        {
            var template = CreateTemplate(viewModel, view);
            Application.Current.Resources.Add(template.DataTemplateKey, template);
        }

        //Maps data templates (http://www.ikriv.com/dev/wpf/DataTemplateCreation/)
        private static DataTemplate CreateTemplate(Type viewModelType, Type viewType)
        {
            string xaml = $"<DataTemplate DataType=\"{{x:Type vm:{viewModelType.Name}}}\"><v:{viewType.Name} /></DataTemplate>";
            var context = new ParserContext
            {
                XamlTypeMapper = new XamlTypeMapper(Array.Empty<string>())
            };
            context.XamlTypeMapper.AddMappingProcessingInstruction("vm", viewModelType.Namespace, viewModelType.Assembly.FullName);
            context.XamlTypeMapper.AddMappingProcessingInstruction("v", viewType.Namespace, viewType.Assembly.FullName);

            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("vm", "vm");
            context.XmlnsDictionary.Add("v", "v");

            var template = (DataTemplate)XamlReader.Parse(xaml, context);
            Console.WriteLine(xaml);
            return template;
        }
    }
}