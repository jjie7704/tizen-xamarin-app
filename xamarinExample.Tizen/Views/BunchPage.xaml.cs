using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tizen.Wearable.CircularUI.Forms;
using xamarinExample.ViewModels;
using xamarinExample.Models;
using xamarinExample.Services;

namespace xamarinExample.Tizen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BunchPage : CirclePage
    {
        public BunchPage(INavigationService navigationService, Bunch bunch)
        {
            InitializeComponent();
            BindingContext = new BunchPageModel(navigationService, bunch);
        }
    }
}