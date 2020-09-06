using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tizen.Wearable.CircularUI.Forms;
using xamarinExample.ViewModels;
using xamarinExample.Services;
using xamarinExample.Models;

namespace xamarinExample.Tizen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CirclePage
    {
        public MainPage(INavigationService navigationService)
        {
            InitializeComponent();
            BindingContext = new MainPageModel(navigationService);
        }
    }
}