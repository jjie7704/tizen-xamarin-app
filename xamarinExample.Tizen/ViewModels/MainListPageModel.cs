using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using xamarinExample.Models;

namespace xamarinExample.Tizen.ViewModels
{
    class MainListPageModel : BasePageModel
    {
        private MainList _mainList;
        private Bunch _selected;
        public INavigation Navigation { get; set; }

        public MainListPageModel(INavigation navigation)
        {
            Navigation = navigation;
            _mainList = new MainList();
            var json = "[ { \"id\": \"a\", \"name\": \"a_name\"}, " +
                "{ \"id\": \"b\", \"name\": \"b_name\"}, " +
                "{ \"id\": \"c\", \"name\": \"c_name\"} ]";
            _mainList.SyncBunchListFromJson(json);
        }

        public ObservableCollection<Bunch> MainList
        {
            get { return _mainList.BunchList; }
        }

        public Bunch Selected
        {
            get { return Selected1; }
            set
            {
                Console.WriteLine($"_selected!! {value.Name} {value.Id}");
                Selected1 = value;
                //Navigation.PushAsync(new ItemListPage(Selected1));
            }
        }

        public Bunch Selected1 { get => _selected; set => _selected = value; }
    }
}
