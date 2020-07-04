using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace xamarinExample.Models
{
    class MainList
    {
        private ObservableCollection<Bunch> _bunchList = new ObservableCollection<Bunch>();

        public MainList()
        {
        }

        public ObservableCollection<Bunch> BunchList
        {
            get { return _bunchList; }
        }

        public void SyncBunchListFromJson(string json)
        {
            _bunchList.Clear();
            try
            {
                IList<BunchData> list = JsonConvert.DeserializeObject<IList<BunchData>>(json); ;
                foreach (var bunch in list)
                {
                    _bunchList.Add(new Bunch(bunch.id, bunch.name));
                    Console.WriteLine($"Bunch {bunch.id}, {bunch.name}");
                }
            }
            catch
            {
                Console.WriteLine($"Invalid json!");
            }
        }
    }
}
