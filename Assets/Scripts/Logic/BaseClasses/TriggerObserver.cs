using Logic.BaseClasses.CustomEventArgs;
using UnityEngine;

namespace Logic.BaseClasses
{
    public class TriggerObserver : ObservableBaseMonoBehaviour<ColliderEventArgs>
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            RaiseEvent(new ColliderEventArgs(other));
        }
    }
}