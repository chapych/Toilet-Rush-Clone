using Drawing;
using UnityEngine;

namespace Character
{
    public interface ILineHolder : IComponent
    {
        ILine Line { get; set; }
        Color Color { get; }
        bool IsFree { get; }
        bool CanBeFinishPoint(Vector2 point);
    }
}