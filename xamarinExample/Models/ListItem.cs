using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinExample.Models
{
    public class ListItem
    {
        private string _id;
        private string _name;

        public ListItem(string id, string name)
        {
            _id = id;
            _name = name;
        }
        public string Id
        {
            get { return _id; }
        }
        public string Name
        {
            get { return _name; }
        }

    }
}
