using System;
using Base.Interfaces;
using Drawing;
using Finish;
using Logic.BaseClasses;
using UnityEngine;

namespace Logic.Character
{
    public interface ILineHolder : IComponent, IKindData
    {
        ILine Line { get; set; }
        IFinishData Finish { get; set; }
        void ShortenLineByPoint();
    }
}