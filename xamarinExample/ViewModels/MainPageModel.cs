using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xamarinExample.Services;

namespace xamarinExample.ViewModels
{
    class MainPageModel : BasePageModel
    {
        private string _welcomeGuide = "Sync data";
        private int _progress = 30;
        private bool _isStartButtonVisible = false;
        private INavigationService _navigationService;

        public ICommand GoNextCommand => new Command(GoNext);

        public Boolean IsStartButtonVisible
        {
            get
            {
                return _isStartButtonVisible;
            }
            set
            {
                SetProperty(ref _isStartButtonVisible, value);
            }
        }

        public int Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                SetProperty(ref _progress, value);
                if (_progress >= 100)
                    IsStartButtonVisible = true;
            }
        }
        public string WelcomeGuide
        {
            get
            {
                return _welcomeGuide;
            }

            set
            {
                SetProperty(ref _welcomeGuide, value);
            }
        }
        public MainPageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                Progress = 100;
                return false;
            });
        }

        private void GoNext()
        {
            _navigationService.NavigateToMainListPageAsync();
        }

    }
}
