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
    class MainListPageModel : BasePageModel
    {
        private INavigationService _navigationService;
        private IRepository _repository;
        private Bunch _selected;
        private IList<Bunch> _bunchList;

        public MainListPageModel(INavigationService navigationService, IRepository repository)
        {
            _navigationService = navigationService;
            _repository = repository;
            _repository.BunchListChanged += OnBunchListChanged;
            MainList = _repository.BunchList;
        }

        private void OnBunchListChanged(object sender, EventArgs e)
        {
            MainList = _repository.BunchList;
        }

        public IList<Bunch> MainList
        {
            get { return _bunchList; }
            set
            {
                SetProperty(ref _bunchList, value);
            }
        }

        public Bunch Selected
        {
            get { return _selected; }
            set
            {
                Console.WriteLine($"_selected!! {value.Name} {value.Id}");
                _selected = value;
                _navigationService.NavigateToBunchPageAsync(_selected);
            }
        }

    }
}
