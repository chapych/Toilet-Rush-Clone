using Character;
using UnityEngine;

namespace Drawing
{
    public interface ILine : IComponent
    {
        Color Color { set; }
        Vector3[] Points { get; }

        bool CanContinue(Vector2 newPosition, float threshold);
        void AddPoint(Vector2 newPosition);
        void SetPoints(Vector3[] current);
        void DestroySelf();
    }
}
