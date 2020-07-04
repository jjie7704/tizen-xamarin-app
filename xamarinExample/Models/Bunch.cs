﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace xamarinExample.Models
{
    public class Bunch
    {
        private ObservableCollection<ListItem> _itemList = new ObservableCollection<ListItem>();
        private string _id = "default";
        private string _name = "no_name";

        public Bunch(string id, string name)
        {
            _id = id;
            _name = name;
        }

        public ObservableCollection<ListItem> ItemList
        {
            get { return _itemList; }
        }
        public string Id
        {
            get { return _id; }
        }
        public string Name
        {
            get { return _name; }
        }

        public void SyncBunchListFromJson(string json)
        {
            _itemList.Clear();
            try
            {
                IList<ListItemData> list = JsonConvert.DeserializeObject<IList<ListItemData>>(json); ;
                foreach (var item in list)
                {
                    _itemList.Add(new ListItem(item.id, item.name));
                    Console.WriteLine($"ListItem {item.id}, {item.name}");
                }
            }
            catch
            {
                Console.WriteLine($"Invalid json!");
            }
        }

    }
}