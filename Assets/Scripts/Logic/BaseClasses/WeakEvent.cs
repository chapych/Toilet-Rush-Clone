using System;
using System.Collections.Generic;

namespace Logic.BaseClasses
{
    public class WeakEvent<TEventArgs>
    {
        private readonly List<WeakReference> listeners = new List<WeakReference>();

        public void AddListener(EventHandler<TEventArgs> handler)
        {
            listeners.Add(new WeakReference(handler));
        }

        public void RemoveListener(EventHandler<TEventArgs> handler)
        {
            listeners.RemoveAll(wr => !wr.IsAlive || wr.Target.Equals(handler));
        }

        public void Raise(object sender, TEventArgs args)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                WeakReference weakReference = listeners[i];
                if (weakReference.IsAlive)
                {
                    ((EventHandler<TEventArgs>)weakReference.Target)?.Invoke(sender, args);
                }
                else
                {
                    listeners.RemoveAt(i);
                }
            }
        }
    }
}