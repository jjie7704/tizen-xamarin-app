using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarinExample.Models;
using xamarinExample.Services;
using xamarinExample.Tizen.Views;

namespace xamarinExample.Tizen.Services
{
    public class NavigationService : INavigationService
    {
        public void Initialize()
        {
            App.Current.MainPage = new NavigationPage(new MainPage(this));
        }

        public Task NavigateToMainListPageAsync()
        {
            var navigationPage = App.Current.MainPage as NavigationPage;
            if (navigationPage != null)
            {
                return navigationPage.PushAsync(new MainListPage(this));
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(new MainListPage(this));
            }
            return Task.FromResult(true);
        }

        public Task NavigateToBunchPageAsync(Bunch bunch)
        {
            var navigationPage = App.Current.MainPage as NavigationPage;
            if (navigationPage != null)
            {
                return navigationPage.PushAsync(new BunchPage(this, bunch));
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(new BunchPage(this, bunch));
            }
            return Task.FromResult(true);
        }

    }
}
