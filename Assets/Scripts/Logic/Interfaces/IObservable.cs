using System;

namespace Logic.Interfaces
{
    public interface IObservable
    {
        public event EventHandler<EventArgs> OnRaised;
        void RaiseEvent();
    }

    public interface IObservable<T> where T : EventArgs
    {
        public event EventHandler<T> OnRaised;
        void RaiseEvent(T args);
    }
}