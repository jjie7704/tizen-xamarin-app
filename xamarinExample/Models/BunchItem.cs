using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinExample.Models
{
    public class BunchItem
    {
        private string _id;
        private string _content;
        private bool _isActive = false;

        public BunchItem(string id, string content, bool isActive)
        {
            _id = id;
            _content = content;
            _isActive = isActive;
        }

        public string Id
        {
            get { return _id; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

    }
}
