using System;

namespace Logic.Interfaces
{
    public interface IObserver
    {
        void Subscribe(IObservable observable);
        void UnSubscribe(IObservable observable);
        public void OnRaisedHandler(object sender, EventArgs args);
    }
}