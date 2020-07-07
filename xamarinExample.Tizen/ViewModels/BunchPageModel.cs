using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using xamarinExample.Models;

namespace xamarinExample.Tizen.ViewModels
{
    class BunchPageModel : BasePageModel
    {
        private Bunch _bunch;
        private ListItem _selected;
        public INavigation Navigation { get; set; }

        public BunchPageModel(INavigation navigation, Bunch bunch)
        {
            Navigation = navigation;
            _bunch = bunch;
            var json = "[ { \"id\": \"a-1\", \"name\": \"a_1_name\"}, " +
                "{ \"id\": \"a-2\", \"name\": \"a_2_name\"}, " +
                "{ \"id\": \"a-3\", \"name\": \"a_3_name\"} ]";
            _bunch.SyncBunchListFromJson(json);
        }

        public ObservableCollection<ListItem> ItemList
        {
            get { return _bunch.ItemList; }
        }

        public ListItem Selected
        {
            get { return _selected; }
            set
            {
                Console.WriteLine($"_selected!! {value.Name} {value.Id}");
                _selected = value;
                //Navigation.PushAsync(new ItemListPage(Selected1));
            }
        }
    }
}
