using System;

namespace Logic.Interfaces
{
    public interface IObservable
    {
        public event EventHandler<EventArgs> OnRaised;
    }
}