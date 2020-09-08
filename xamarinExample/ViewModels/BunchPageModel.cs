using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using xamarinExample.Models;
using xamarinExample.Services;

namespace xamarinExample.ViewModels
{
    class BunchPageModel : BasePageModel
    {
        private INavigationService _navigationService;
        private Bunch _bunch;
        private BunchItem _selected;
        public INavigation Navigation { get; set; }

        public BunchPageModel(INavigationService navigationService, Bunch bunch)
        {
            _navigationService = navigationService;
            _bunch = bunch;
        }

        public IList<BunchItem> ItemList
        {
            get { return _bunch.ItemList; }
        }

        public BunchItem Selected
        {
            get { return _selected; }
            set
            {
                Console.WriteLine($"_selected!! {value.Content} {value.Id}");
                _selected = value;
            }
        }
    }
}
