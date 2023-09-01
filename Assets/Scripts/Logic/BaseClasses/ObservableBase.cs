using System;
using Logic.Interfaces;

namespace Logic.BaseClasses
{
    public class ObservableBase : IObservable
    {
        private readonly WeakEvent<EventArgs> @event = new WeakEvent<EventArgs>();

        public event EventHandler<EventArgs> OnRaised    
        {
            add => @event.AddListener(value);
            remove => @event.RemoveListener(value);
        }
        
        public void RaiseEvent()
        { 
            @event.Raise(this, EventArgs.Empty);
        }
    }

    public class ObservableBase<T> : Interfaces.IObservable<T> where T : EventArgs

    {
    private readonly WeakEvent<T> @event = new WeakEvent<T>();

    public event EventHandler<T> OnRaised
    {
        add => @event.AddListener(value);
        remove => @event.RemoveListener(value);
    }

    public void RaiseEvent(T args)
    {
        @event.Raise(this, args);
    }
    }
}