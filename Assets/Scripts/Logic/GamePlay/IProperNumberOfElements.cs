using System;
using Base.Interfaces;

namespace Logic.GamePlay
{
    public interface IProperNumberOfElements
    {
        void OnOneElementHandler();
        event Action OnAllElements;
    }
}