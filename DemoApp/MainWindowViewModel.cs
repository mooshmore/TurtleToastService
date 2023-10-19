using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleToastSerice.Service;
using TurtleToastService.Service.Service;
using Utilities.WPF.Bases;

namespace TurtleToastService.DemoApp
{
    internal class MainWindowViewModel
    {
        public RelayCommand InformationLowCommand { get; } = new RelayCommand(() => TurtleToast.Information("Information toast low priority", Priority.Low));
        public RelayCommand InformationMediumCommand { get; } = new RelayCommand(() => TurtleToast.Information("Information toast medium priority", Priority.Medium));
        public RelayCommand InformationHighCommand { get; } = new RelayCommand(() => TurtleToast.Information("Information toast high priority", Priority.High));
    }
}
