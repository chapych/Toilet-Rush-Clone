using System;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.Character
{
    public interface IMovable
    {
        void StartMovement(Queue<Vector2> queue, Action onPointWalkedBy = null, Action onMovementFinished = null);
    }
}