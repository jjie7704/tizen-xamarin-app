using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace xamarinExample.Tizen.ViewModels
{
    class MainPageModel : BasePageModel
    {
        private string _welcomeGuide = "Sync data";
        private int _progress = 30;

        public int Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                SetProperty(ref _progress, value);
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
    }
}
