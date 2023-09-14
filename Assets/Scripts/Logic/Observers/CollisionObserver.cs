using System;
using Logic.BaseClasses.CustomEventArgs;
using UnityEngine;

namespace Logic.BaseClasses
{
    [Serializable]
    public class CollisionObserver : MonoBehaviour
    {
        public event EventHandler<CollisionEventArgs> OnCollision;
        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision?.Invoke(this, new CollisionEventArgs(other));
        }
    }
}