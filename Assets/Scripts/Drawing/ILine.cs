using System.Collections.Generic;
using UnityEngine;

public interface ILine
{
    Color Color { set; }
    Vector3[] Points { get; }

    bool CanContinue(Vector2 newPosition, float threshold);
    void Continue(Vector2 newPosition);
}
