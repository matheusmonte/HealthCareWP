using Caliburn.Micro;
using HealthCare.ViewModel;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using HealthCare.View;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace HealthCare
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : CaliburnApplication
    {
        private WinRTContainer container;

        public App()
        {
            InitializeComponent();

        }

        protected override void Configure()
        {
            container = new WinRTContainer();

            container.RegisterWinRTServices();
            //Adicione aqui as suas ViewModels
            container.Singleton<MainPageViewModel>();
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            //Adicione aqui a primeira página do seu app
            DisplayRootView<MainPageView>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}