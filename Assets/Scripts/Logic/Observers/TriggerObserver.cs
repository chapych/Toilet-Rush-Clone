using System;
using Logic.BaseClasses.CustomEventArgs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Logic.BaseClasses
{
    [Serializable]
    public class TriggerObserver : MonoBehaviour
    {
        public event EventHandler<ColliderEventArgs> OnTrigger;
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTrigger?.Invoke(this, new ColliderEventArgs(other));
        }
    }
}