using Caliburn.Micro;
using System.Collections.Generic;
using System.Text;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Core;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.ApplicationModel.Core;
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace HealthCare.ViewModel
{
    public class MainPageViewModel : Screen
    {
        public MainPageViewModel()
        {
        }

        private IObservableCollection<string> _pressaoResults;
        public IObservableCollection<string> PressaoResults
        {
            get
            {
                return _pressaoResults;
            }
            set
            {
                _pressaoResults = value;
                NotifyOfPropertyChange(() => PressaoResults);
            }
        }

        private IObservableCollection<string> _glicoseResults;
        public IObservableCollection<string> GlicoseResults
        {
            get
            {
                return _glicoseResults;
            }
            set
            {
                _glicoseResults = value;
                NotifyOfPropertyChange(() => GlicoseResults);
            }
        }

        private Visibility _noResultsGlicoseVisibility;
        public Visibility NoResultsGlicoseVisibility
        {
            get
            {
                return _noResultsGlicoseVisibility;
            }
            set
            {
                _noResultsGlicoseVisibility = value;
                NotifyOfPropertyChange(() => NoResultsGlicoseVisibility);
            }
        }

        private Visibility _noResultsPressaoVisibility;
        public Visibility NoResultsPressaoVisibility
        {
            get
            {
                return _noResultsPressaoVisibility;
            }
            set
            {
                _noResultsPressaoVisibility = value;
                NotifyOfPropertyChange(() => NoResultsPressaoVisibility);
            }
        }
        protected override void OnActivate()
        {
            base.OnActivate();
            if (PressaoResults == null)
            {
                NoResultsPressaoVisibility = Visibility.Visible;
            }
            if (GlicoseResults == null)
            {
                NoResultsGlicoseVisibility = Visibility.Visible;
            }

        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }
    }

}
