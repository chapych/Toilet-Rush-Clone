using System;
using UnityEngine;

namespace Drawing
{
    public interface ILineCreator
    {
        event Action OnProperLineCreated;
        ILine CurrentLine { get; set; }
        ILine Create(Vector2 position);
        void ContinueLine(Vector2 position);
    }
}