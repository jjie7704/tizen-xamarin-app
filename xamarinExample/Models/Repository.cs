using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinExample.Models
{
    class Repository : IRepository
    {
        private IDictionary<string, Bunch> _bunchMap = new Dictionary<string, Bunch>();
        public event EventHandler BunchListChanged;

        public Repository()
        {
            InitBunchList();
        }

        public IList<Bunch> BunchList
        {
            get { return new List<Bunch>(_bunchMap.Values); }
        }

        public void UpdateBunchList(string json)
        {
            var newMap = new Dictionary<string, Bunch>();
            try
            {
                IList<BunchData> list = JsonConvert.DeserializeObject<IList<BunchData>>(json);
                foreach (var bunch in list)
                {
                    if (_bunchMap.TryGetValue(bunch.id, out Bunch old))
                    {
                        newMap.Add(bunch.id, old);
                    }
                    else
                    {
                        newMap.Add(bunch.id, new Bunch(bunch.id, bunch.name));
                    }
                    Console.WriteLine($"Bunch {bunch.id}, {bunch.name}");
                }
                _bunchMap = newMap;
                PutBunchList();
                OnBunchListChanged();
            }
            catch
            {
                Console.WriteLine($"Invalid json!");
            }
        }

        public void UpdateBunch(string id, string json)
        {
            IList<BunchItem> itemList = new List<BunchItem>();
            try
            {
                IList<BunchItemData> list = JsonConvert.DeserializeObject<IList<BunchItemData>>(json); ;
                foreach (var item in list)
                {
                    itemList.Add(new BunchItem(item.id, item.content, item.isActive));
                    Console.WriteLine($"ListItem {item.id}, {item.content}, {item.isActive}");
                }
                if (_bunchMap.TryGetValue(id, out Bunch targetBunch))
                {
                    targetBunch.UpdateItems(itemList);
                    PutBunch();
                }
            }
            catch
            {
                Console.WriteLine($"Invalid json!");
            }
        }

        protected virtual void OnBunchListChanged()
        {
            EventHandler handler = BunchListChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        private void InitBunchList()
        {
            // update from sql
        }

        private void PutBunchList()
        {
            // insert to sql
        }

        private void PutBunch()
        {
            // insert to sql
        }

    }
}
