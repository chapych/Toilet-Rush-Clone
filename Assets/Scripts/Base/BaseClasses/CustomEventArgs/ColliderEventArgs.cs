using System;
using UnityEngine;

namespace Logic.BaseClasses.CustomEventArgs
{
    public class ColliderEventArgs : EventArgs
    {
        public Collider2D Collider { get; set; }

        public ColliderEventArgs(Collider2D Collider) => this.Collider = Collider;
    }
}