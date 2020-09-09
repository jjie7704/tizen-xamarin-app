using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinExample.Models
{
    public interface IRepository
    {
        event EventHandler BunchListChanged;
        IList<Bunch> BunchList { get; }
        public void Update(string json);
    }
}
