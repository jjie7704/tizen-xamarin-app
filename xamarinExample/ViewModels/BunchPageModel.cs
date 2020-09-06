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
            var json = "[ { \"id\": \"a-1\", \"name\": \"a_1_name\"}, " +
                "{ \"id\": \"a-2\", \"name\": \"a_2_name\"}, " +
                "{ \"id\": \"a-3\", \"name\": \"a_3_name\"} ]";
            _bunch.SyncBunchListFromJson(json);
        }

        public ObservableCollection<BunchItem> ItemList
        {
            get { return _bunch.ItemList; }
        }

        public BunchItem Selected
        {
            get { return _selected; }
            set
            {
                Console.WriteLine($"_selected!! {value.Name} {value.Id}");
                _selected = value;
            }
        }
    }
}
