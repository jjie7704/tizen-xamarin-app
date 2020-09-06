using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinExample.Models
{
    public interface IRepository
    {
        event EventHandler BunchListChanged;

        IList<Bunch> GetBunchList();
        void UpdateBunchList(string json);
    }
}
