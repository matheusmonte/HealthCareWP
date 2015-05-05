using Caliburn.Micro;
using System.Collections.Generic;
using System.Text;
using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Core;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.ApplicationModel.Core;
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using HealthCare.DataSaver;
using HealthCare.Model;

namespace HealthCare.ViewModels
{
    public class MainPageViewModel : Screen
    {
        private DataAccess _dataAccess;
        protected readonly IEventAggregator _eventAggregator;
        protected readonly INavigationService _navigationService;
       
        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _dataAccess = new DataAccess();
        }
        #region Binding 
        private ObservableCollection<ArterialPressureModel> _pressaoResults;
        public ObservableCollection<ArterialPressureModel> PressaoResults
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

        private ObservableCollection<GlicoseModel> _glicoseResults;
        public ObservableCollection<GlicoseModel> GlicoseResults
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

        #endregion
        protected override void OnActivate()
        {

            List<ArterialPressureModel> arterialPressureList = _dataAccess.RecoveryPressureData();
            if (arterialPressureList != null)
            {
                PressaoResults = new ObservableCollection<ArterialPressureModel>(arterialPressureList);
            }
            List<GlicoseModel> glicoseList = _dataAccess.RecoveryGlicoseData();
            if (glicoseList != null)
            {
                GlicoseResults = new ObservableCollection<GlicoseModel>(glicoseList);
            }

            if (PressaoResults == null)
            {
                NoResultsPressaoVisibility = Visibility.Visible;
            }
            if (GlicoseResults == null)
            {
                NoResultsGlicoseVisibility = Visibility.Visible;
            }

        }
        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
           
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }
    }

}
