﻿using System;
using TurtleToastSerice.Service;
using TurtleToastService.Service.Core;
using TurtleToastService.Service.ToastStyling;
using TurtleToastService.Service.Views.Loading;
using Utilities.WPF.Bases;

namespace TurtleToastService.DemoApp
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            // Todo: change project folder naming to fit the projects.
            LoadingCountCommand = new RelayCommand(LoadingCountSimulation);
            LoadingInfiniteCommand = new RelayCommand(LoadingInfiniteSimulation);
            IncreaseCountCommand = new RelayCommand(() => LoadingEvent?.Invoke(null, null));
            EndLoadingCommand = new RelayCommand(() => _completeToast?.Invoke(null, null));
        }

        public RelayCommand InformationToastCommand { get; } = new RelayCommand(InformationToast);
        public RelayCommand ConfirmationToastCommand { get; } = new RelayCommand(ConfirmationToast);
        public RelayCommand LoadingCountCommand { get; }
        public RelayCommand LoadingInfiniteCommand { get; }
        public RelayCommand IncreaseCountCommand { get; }
        public RelayCommand EndLoadingCommand { get; }
        public RelayCommand ClearAllToastsCommand { get; } = new RelayCommand(TurtleToast.ClearAll);
        public RelayCommand ClearUpcomingToastsCommand { get; } = new RelayCommand(TurtleToast.ClearUpcoming);
        public RelayCommand ChangeThemeCommand { get; } = new RelayCommand(ChangeTheme);

        private static void InformationToast(object toastPriority)
        {
            switch ((Priority)toastPriority)
            {
                case Priority.Low:
                    TurtleToast.Information("Information toast low priority", Priority.Low);
                    break;
                case Priority.Medium:
                    TurtleToast.Information("Information toast medium priority", Priority.Medium);
                    break;
                case Priority.High:
                    TurtleToast.Information("Information toast high priority", Priority.High);
                    break;
            }
        }

        private static void ConfirmationToast(object toastPriority)
        {
            switch ((Priority)toastPriority)
            {
                case Priority.Low:
                    TurtleToast.Confirmation("ConfirmationToast toast low priority", Priority.Low);
                    break;
                case Priority.Medium:
                    TurtleToast.Confirmation("ConfirmationToast toast medium priority", Priority.Medium);
                    break;
                case Priority.High:
                    TurtleToast.Confirmation("ConfirmationToast toast high priority", Priority.High);
                    break;
            }
        }

        private int _loadingMaxCount = 5;

        public event EventHandler LoadingEvent;
        public void LoadingCountSimulation()
        {
            _completeToast = TurtleToast.Loading("Loading count", "This can take a while", _loadingMaxCount, progressEvent: ref LoadingEvent, displayMode: ProgressDisplayMode.FullCount);
        }

        public void LoadingInfiniteSimulation()
        {
            _completeToast = TurtleToast.Loading("Loading infinite", "This can take a while", progressEvent: ref LoadingEvent, displayMode: ProgressDisplayMode.Count);
        }

        public static void ChangeTheme(object theme) => TurtleToast.ChangeTheme((ToastTheme)theme);

        private EventHandler _completeToast;
    }
}
