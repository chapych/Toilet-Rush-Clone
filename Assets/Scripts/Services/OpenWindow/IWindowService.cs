using Base.BaseClasses.Enums;
using Logic.BaseClasses;
using UnityEngine;

namespace Services.OpenWindow
{
    public interface IWindowService
    {
        void Open(WindowType windowType);
        void CloseLastOpened();
    }
}