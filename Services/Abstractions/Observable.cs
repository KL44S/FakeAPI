using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public abstract class Observable
    {
        protected IList<IObserver> _observers;

        public Observable()
        {
            this._observers = new List<IObserver>();
        }

        public void AddObserver(IObserver Observer)
        {
            this._observers.Add(Observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver Observer in this._observers)
            {
                Observer.IhaveBeenChanged(this);
            }
        }

        public void NotifyObservers(object Params)
        {
            foreach (IObserver Observer in this._observers)
            {
                Observer.IhaveBeenChanged(this, Params);
            }
        }
    }
}
