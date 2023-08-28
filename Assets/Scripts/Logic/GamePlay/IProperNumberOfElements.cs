using System;
using Logic.Interfaces;

namespace Logic.GamePlay
{
    public interface IProperNumberOfElements
    {
        void OnOneElementHandle(object sender, EventArgs e);
        void Subscribe(IObservable observable);
        void UnSubscribe(IObservable observable);
    }
}