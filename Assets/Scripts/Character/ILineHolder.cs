using Drawing;
using UnityEngine;

namespace Character
{
    public interface ILineHolder : IComponent
    {
        ILine Line { get; set; }
        bool IsFree { get; }
        Color Color { get; }
        bool CanBeFinishPoint(Vector2 point);
    }
}