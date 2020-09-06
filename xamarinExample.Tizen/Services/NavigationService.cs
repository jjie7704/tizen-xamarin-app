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
        private IRepository _repository;

        public NavigationService()
        {
            _repository = new Repository();
            var json = "[ { \"id\": \"bunch_a\", \"name\": \"a_name\"}, " +
                "{ \"id\": \"bunch_b\", \"name\": \"b_name\"}, " +
                "{ \"id\": \"bunch_c\", \"name\": \"c_name\"} ]";
            _repository.UpdateBunchList(json);
        }

        public void Initialize()
        {
            App.Current.MainPage = new NavigationPage(new MainPage(this));
        }

        public Task NavigateToMainListPageAsync()
        {
            var navigationPage = App.Current.MainPage as NavigationPage;
            if (navigationPage != null)
            {
                return navigationPage.PushAsync(new MainListPage(this, _repository));
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(new MainListPage(this, _repository));
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
