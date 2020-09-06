using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinExample.Models
{
    class Repository : IRepository
    {
        private IList<Bunch> _bunchList = new List<Bunch>();
        public event EventHandler BunchListChanged;

        public Repository()
        {
            InitBunchList();
        }

        public IList<Bunch> BunchList
        {
            get { return new List<Bunch>(_bunchList); }
        }

        public void UpdateBunchList(string json)
        {
            _bunchList.Clear();
            try
            {
                IList<BunchData> list = JsonConvert.DeserializeObject<IList<BunchData>>(json);
                foreach (var bunch in list)
                {
                    _bunchList.Add(new Bunch(bunch.id, bunch.name));
                    Console.WriteLine($"Bunch {bunch.id}, {bunch.name}");
                }
                PutBunchList();
                OnBunchListChanged();
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
    }
}
