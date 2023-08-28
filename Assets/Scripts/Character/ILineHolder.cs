using Drawing;
using Finish;
using UnityEngine;

namespace Character
{
    public interface ILineHolder : IComponent
    {
        ILine Line { get; set; }
        Color Color { get; }
        bool IsFree { get; }
        bool CanBeFinishPoint(IFinishData finishData);
        void Configure(IFinishData finish);
    }
}