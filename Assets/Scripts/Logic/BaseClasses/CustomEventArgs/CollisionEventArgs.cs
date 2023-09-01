using System;
using UnityEngine;

namespace Logic.BaseClasses.CustomEventArgs
{
    public class CollisionEventArgs : EventArgs
    {
        public Collision2D Collision { get; set; }

        public CollisionEventArgs(Collision2D collision) => Collision = collision;
    }
}