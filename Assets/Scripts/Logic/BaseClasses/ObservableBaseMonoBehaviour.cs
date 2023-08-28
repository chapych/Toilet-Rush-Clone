using System;
using Logic.Interfaces;
using UnityEngine;

namespace Logic.BaseClasses
{
    public class ObservableBaseMonoBehaviour : MonoBehaviour, IObservable
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
}