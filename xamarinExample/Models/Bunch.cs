using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace xamarinExample.Models
{
    public class Bunch
    {
        private IDictionary<string, BunchItem> _itemMap = new Dictionary<string, BunchItem>();
        private string _id = "default";
        private string _name = "no_name";
        public event EventHandler BunchChanged;

        public Bunch(string id, string name)
        {
            _id = id;
            _name = name;
        }

        public IList<BunchItem> ItemList
        {
            get { return new List<BunchItem>(_itemMap.Values); }
        }

        public string Id
        {
            get { return _id; }
        }
        public string Name
        {
            get { return _name; }
        }

        public void UpdateItems(IList<BunchItem> itemList)
        {
            IDictionary<string, BunchItem> newItemMap = new Dictionary<string, BunchItem>();
            bool isChanged;
            foreach (var item in itemList)
            {
                if (_itemMap.TryGetValue(item.Id, out BunchItem target))
                {
                    if (target.Content.Equals(item.Content)
                        && target.IsActive != item.IsActive)
                    {
                        newItemMap.Add(item.Id, target);
                    }
                    else
                    {
                        isChanged = true;
                        target.Content = item.Content;
                        target.IsActive = item.IsActive;
                        newItemMap.Add(item.Id, target);
                    }
                }
                else
                {
                    isChanged = true;
                    newItemMap.Add(item.Id, new BunchItem(item.Id, item.Content, item.IsActive));
                }
            }

            isChanged = newItemMap.Count != _itemMap.Count || !newItemMap.Keys.SequenceEqual(_itemMap.Keys);

            if (isChanged)
                OnBunchChanged();
        }

        protected virtual void OnBunchChanged()
        {
            EventHandler handler = BunchChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
