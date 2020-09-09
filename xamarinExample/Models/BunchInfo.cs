using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinExample.Models
{
    public class BunchInfo
    {
        public IList<BunchData> bunchList { get; set; }
        public IList<BunchDetail> bunchs { get; set; }
    }

    public class BunchData
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class BunchDetail
    {
        public string id { get; set; }
        public IList<BunchItemData> items { get; set; }
    }

    public class BunchItemData
    {
        public string id { get; set; }
        public string content { get; set; }
        public bool isActive { get; set; }
    }
}
