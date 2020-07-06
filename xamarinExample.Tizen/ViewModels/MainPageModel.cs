using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xamarinExample.Tizen.Views;

namespace xamarinExample.Tizen.ViewModels
{
    class MainPageModel : BasePageModel
    {
        private string _welcomeGuide = "Sync data";
        private int _progress = 30;
        private bool _isStartButtonVisible = false;

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
        public MainPageModel()
        {
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                Progress = 100;
                return false;
            });
        }

        private void GoNext()
        {
            Application.Current.MainPage = new NavigationPage(new MainListPage());
        }

    }
}
