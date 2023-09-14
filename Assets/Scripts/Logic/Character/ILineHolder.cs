using Base.Interfaces;
using Drawing;
using Finish;
using Logic.BaseClasses;
using UnityEngine;

namespace Logic.Character
{
    public interface ILineHolder : IComponent
    {
        ILine Line { get; set; }
        Kind Kind { get; set; }
        IFinishData Finish { get; set; }
        void ShortenLineByPoint();
    }
}