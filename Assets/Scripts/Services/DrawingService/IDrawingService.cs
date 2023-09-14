using System;
using Base.Interfaces;

namespace Logic.Drawing
{
    public interface IDrawingService
    {
        void Initialise();
        void TurnOnDrawing();
        void TurnOffDrawing();
        event Action OnDrawn;
    }
}