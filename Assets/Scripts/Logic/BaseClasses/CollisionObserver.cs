using System;
using Logic.BaseClasses.CustomEventArgs;
using UnityEngine;

namespace Logic.BaseClasses
{
    public class CollisionObserver : ObservableBaseMonoBehaviour<CollisionEventArgs>
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            RaiseEvent(new CollisionEventArgs(other));
        }
    }
}