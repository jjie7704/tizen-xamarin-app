using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        private void UpdateBunchList(IList<BunchData> bunchList)
        {
            var newMap = new Dictionary<string, Bunch>();
            foreach (var bunch in bunchList)
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

        private void UpdateBunch(string id, IList<BunchItemData> items)
        {
            if (_bunchMap.TryGetValue(id, out Bunch targetBunch))
            {
                IList<BunchItem> itemList = new List<BunchItem>();
                foreach (var item in items)
                {
                    itemList.Add(new BunchItem(item.id, item.content, item.isActive));
                    Console.WriteLine($"ListItem {item.id}, {item.content}, {item.isActive}");
                }
                targetBunch.UpdateItems(itemList);
                PutBunch();
            }
            else
            {
                Console.WriteLine($"Invaild bunch Id: {id}");
            }
        }

        public void Update(string json)
        {
            try
            {
                BunchInfo info = JsonConvert.DeserializeObject<BunchInfo>(json);
                Console.WriteLine($"bunchList: {info.bunchList}");
                if (info.bunchList != null)
                    UpdateBunchList(info.bunchList);

                if (info.bunchs == null)
                    return;

                Console.WriteLine($"bunchs: {info.bunchs}");
                foreach (var bunch in info.bunchs)
                {
                    UpdateBunch(bunch.id, bunch.items);
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