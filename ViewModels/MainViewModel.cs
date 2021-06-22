using System;
using System.Windows;
using EZNavLib;
using EZNavLib.Interfaces;

namespace NavigationApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties and Fields

        /// <summary>
        /// Lazy instantiation of this class, triggered by the DataContext binding in xaml
        /// </summary>
        private static readonly Lazy<MainViewModel> _Instance = new(() => new MainViewModel());

        /// <summary>
        /// Retrieves the instance of this class
        /// </summary>
        public static MainViewModel Instance
        {
            get
            {
                return _Instance.Value;
            }
        }

        /// <summary>
        /// Navigation object providing page navigation and data context
        /// </summary>
        public Navigator Navigator
        {
            get;
            private set;
        } = new Navigator(new MainMenuViewModel());

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of this class. Invoked by lazy instantiation
        /// </summary>
        private MainViewModel()
            : base()
        {
            _ = Navigator.OpenFirstPage();
            Navigator.NavigationFinished += OnNavigationFinished;
        }

        #endregion

        private void OnNavigationFinished(object sender, NavigationFinishedEventArgs e)
        {
            if (e.PageResult is SelectIntegerPageResult integerPageResult)
            {
                MessageBox.Show($"Result: {integerPageResult.SelectedInteger}",
                    "Navigation finished",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
    }
}
